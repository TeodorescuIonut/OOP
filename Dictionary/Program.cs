using System;

namespace Dictionary
{
    class Program
    {
        static void Main()
        {
            var dictionary = new MyDictionary<int, string>(5);
            dictionary.Add(1, "a");

            string value;
            const int test = 1;
            if (dictionary.TryGetValue(test, out value))
            {
                Console.WriteLine("For key = \"tif\", value = {0}.", value);
            }
            else
            {
                Console.WriteLine("Key = \"tif\" is not found.");
            }
        }
    }
}
