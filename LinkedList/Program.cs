using System;

namespace LinkedList
{
    class Program
    {
        static void Main()
        {
            CircularDoublyLinkedListCollection<string> mylist = new CircularDoublyLinkedListCollection<string>();
            const string numberFour = "the";
            mylist.Add(numberFour);
            mylist.Add("Blue");
            mylist.Add("Eyes");
            mylist.AddFirst("at");
            mylist.AddFirst("Look");
            mylist.Find("the");
            Console.WriteLine(mylist.Contains("The"));
            Node<string> currentNode;
            currentNode = mylist.Find("Eyes");
            mylist.AddAfter(currentNode, "smile");
            mylist.AddBefore(currentNode, "and");
            mylist.Add("the");
            Console.WriteLine(mylist.FindLast("the"));
            mylist.RemoveFirst();
            mylist.Remove("Eyes");
            string[] myarray = new string[mylist.Count];
            mylist.CopyTo(myarray, 0);

            foreach (string s in myarray)
            {
                Console.WriteLine(s);
            }

            var enumeratorReadOnly = mylist.GetEnumerator();
            while (enumeratorReadOnly.MoveNext())
            {
                Console.WriteLine(enumeratorReadOnly.Current);
            }

            mylist.PrintList();
        }
    }
}
