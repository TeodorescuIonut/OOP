using JSONclasses;
using System;

namespace JSONTest
{
    class Program
    {
        static void Main()
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\Ionut\Documents\GitHub\OOP\JSON classes\WriteText.txt");
            var value = new Value();
            Console.WriteLine(value.Match(text).Success() ? text + " is a valid JSON format" : text + " is not  a valid JSON format");
        }
       
    }
}
