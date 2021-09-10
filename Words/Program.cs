using System;
using System.Linq;

namespace Words
{
    class Program
    {
        static void Main()
        {
            string word = "aabbbbeitu";

            char[] vowels = new char[5] { 'a', 'e', 'i', 'o', 'u' };
            var vowelsNumber = word.ToCharArray().Where(x => vowels.Contains(x)).Count();
            var consonantNumber = word.ToCharArray().Where(x => !vowels.Contains(x)).Count();
            Console.WriteLine("No of vowels is:" + vowelsNumber +" and consonants: " +consonantNumber);
            var firstNonRepeatedChar = word.GroupBy(x => x).Where(x => x.Count() == 1).First();
            Console.WriteLine(firstNonRepeatedChar.Key);
            var asIntegers = word.Select(i => i);
            var doubles = from char item in asIntegers select (int)item;
            foreach ( var item in doubles)
            {
                Console.WriteLine(item);
            }
        }

    }
}
