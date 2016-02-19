using System;
using Serilog;
namespace Console_Notes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Note: The main program is so much more legible

            // Prompts the user to either read, write or exit the softw

       
            while (true)
            {
                Console.Write("\tPlease enter 1 to read old notes and 2 to write a note, press 3 to exit: ");
                var choice = 0;
                var note = new Note();
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                       
                        SQLDatabaseHelper.Read();
                        
                        break;
                    case 2:
                        note.WriteNote();
                        break;
                    case 3:
                       System.Environment.Exit(1);
                        break;

                }
            }
           
            

           
          
           
           Console.ReadLine();
        }
    }
}
