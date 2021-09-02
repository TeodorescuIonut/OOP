using System;
using System.Linq;

namespace Words
{
    class Program
    {
        static void Main()
        {
            string word = "hello";
            var VovelsAndConson = word.ToCharArray();
            var number = VovelsAndConson.All(v => v == 108);
            Console.WriteLine(number);
        }

    }
}
