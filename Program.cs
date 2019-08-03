using Assignment2.Testdata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

            String path= Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            List<String> arr = new List<string>();
             arr = ExcelRead.ReadExcel(path + "\\Testdata.Xlsx", 1);

                  foreach (String item in arr)
                        {
                          Console.WriteLine(item);
                  }
            //        Console.Read();
            Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
