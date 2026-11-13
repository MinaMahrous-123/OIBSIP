using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helper
{
    public static class ExceptionLogger
    {

        public static void Logs(string message)
        {
            string logDirectory = Path.Combine( AppContext.BaseDirectory,"Logs");
            Console.WriteLine("Log Path: " + logDirectory);
            //string logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            Directory.CreateDirectory(logDirectory); // Ensures the Logs folder exists

            string fileName = $"Log_{DateTime.Now:yyyy-MM-dd}.txt"; // Formats date as 2025-10-12
            string path = Path.Combine(logDirectory, fileName);

            using (var stream = new StreamWriter(path, append: true))
            {
                stream.WriteLine(message);
            }
        }

    }
}
