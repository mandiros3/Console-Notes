using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;



namespace Console_Notes
{
  public  static class SQLDatabaseHelper
       
        
        // TODO Try to simply connect to db, because db is already created
    {
        private static SQLiteConnection _dbConnection;

        #region Database creation methods
        //****************** Methods that were used to create database, I'll leave them for posterity

        //// Creates an empty database file
        //public void CreateNewDatabase()
        //{
        //    SQLiteConnection.CreateFile("notesDB.sqlite");
        //}


        //// Creates a table 
        //public void CreateTable()
        //{
        //    string sql = "create table notes (id INTEGER PRIMARY KEY  NOT NULL , date VARCHAR NOT NULL  DEFAULT CURRENT_DATE, title VARCHAR, post TEXT)";
        //    SQLiteCommand command = new SQLiteCommand(sql, _dbConnection);
        //    command.ExecuteNonQuery();
        //}

        //**********************************************************************************

        #endregion
        #region Connect to DB
        // Creates a connection to database file
        public static void ConnectDatabase()
        {
            _dbConnection = new SQLiteConnection("Data Source=notesDB.sqlite;Version=3;");
            _dbConnection.Open();
        } 
        #endregion

        #region Insert Notes
        //Gets query string, connects to database then applies query

        public static void Insert(string query)
        {

            //TODO  Get value from note class here
            string sql = query;
            ConnectDatabase();
            SQLiteCommand command = new SQLiteCommand(sql, _dbConnection);
            command.ExecuteNonQuery();

        }
        #endregion

        #region Read Notes
        // Looks through database columns then display values in the console

        public static void Read()
        {
            string sql = "select * from notes order by date desc";
            ConnectDatabase();
            SQLiteCommand command = new SQLiteCommand(sql, _dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Date written:" + reader["date"] + "\n" +
                     "Title:" + reader["title"] + "\n" +
                     "Post:" + reader["post"] + "\n"
                 );
            }

        } 
        #endregion

    }
}
