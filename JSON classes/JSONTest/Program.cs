using System;
using System.IO;

namespace JSONclasses
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please enter a valid path.");
            }
            else
            {
                string path = args[0];
                if (File.Exists(path))
                {
                    string fileName = Path.GetFileName(path);
                    string text = File.ReadAllText(path);
                    var value = new Value();
                    Console.WriteLine(value.Match(text).Success() && value.Match(text).RemainingText() == ""
                                     ? fileName + " contains valid JSON format"
                                     : fileName + " doesnt contain valid JSON format");
                }
                else
                {
                    Console.WriteLine("Path doesn't exist. Please enter a valid path.");
                }
            }
        }
    }
}
