using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Console_Notes
{
    public class Note
    {
       
        private string title;
        private string post { get; set; }

        //Empty contructor
        public Note()
        {

        }

        //Constructor what was used for testing. Should be removed
        public Note(string _title, string _post)
        {

           
            title = _title;
            post = _post;
        }
        // Prompts the user to input data, then calls saveNote Method
        public void WriteNote()
        {
            Console.WriteLine("Enter Note Title: ");
            title = Console.ReadLine();
            Console.WriteLine("Enter Note: ");
            post = Console.ReadLine();
         
            SaveNote();

        }
        //SaveNote Method, Passes the query string to the database helper. String data: title and post come
        // from user input
        public void SaveNote()
        {
            Console.WriteLine("Note saved");
            //using String interpolation alternatively, I should look into this

            string query = string.Format("insert into notes ( title, post) values ('{0}', '{1}')", title, post);
            SQLDatabaseHelper.Insert(query);

        }




  
    }
}

