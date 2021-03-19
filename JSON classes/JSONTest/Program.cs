using JSONclasses;
using System;

namespace JSONTest
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            text = System.IO.File.ReadAllText(@text);
            var value = new Value();
            Console.WriteLine(value.Match(text).Success() && value.Match(text).RemainingText() == ""
                                ? text + " is a valid JSON format"
                                : text + " is not  a valid JSON format");       
        }
       
    }
}
