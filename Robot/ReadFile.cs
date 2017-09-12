using System;
using System.IO;
using System.Security;

namespace Robot
{
    class ReadFile
    {
        public string[] ReadingFile()
        {
            string[] instr = null;
            string fileName;

            Console.WriteLine("Please insert instruction file name: ");
            fileName = Console.ReadLine();
            if (!fileName.EndsWith(".txt"))
            {
                fileName += ".txt";
            }

            try
            {
                instr = File.ReadAllLines(fileName);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Selected file does not exist. Please select other one.");
                Console.WriteLine("Application will close now.aaa");
                Console.ReadKey();
                Environment.Exit(0);
            }
            catch (SecurityException)
            {
                Console.WriteLine("No permissions to open that file.");
                Console.WriteLine("Application will close now.aaa");
                Console.ReadKey();
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is ArgumentNullException || ex is PathTooLongException || ex is DirectoryNotFoundException || ex is NotSupportedException)
                {
                    Console.WriteLine("Invalid path.");
                }
                else if(ex is IOException || ex is UnauthorizedAccessException)
                {
                    Console.WriteLine("Cannot open selected file");
                }
                else
                {
                    Console.WriteLine("Unexpected error during opening selected file.");
                }
                Console.WriteLine("Application will close now.aaa");
                Console.ReadKey();
                Environment.Exit(0);
            }
            return instr;
        }
    }
}
