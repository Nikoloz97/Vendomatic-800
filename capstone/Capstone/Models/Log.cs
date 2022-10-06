using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Models
{
   public static  class Log
    {
        

        public void WriteToLog(string msg)
        {
            string directory = Environment.CurrentDirectory;
            string fileName = "Log.txt";


            try
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(directory, fileName), true))
                {
                    sw.WriteLine(msg);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Oops, Something Wrong happened, Logging failed");
            }
        }

    }
}
