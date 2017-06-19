using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExamples
{
    class GenericCollections
    {

        public void TestSortedSet()
        {
            SortedSet<string> set = new SortedSet<string>(new string[] { "pako", "foo" });
            set.Add("bar");
            set.Add("bim");
            foreach (var str in set)
                Console.WriteLine(str);

            int count = set.Count;
            string max = set.Max();
            string min  = set.Min();
            Console.WriteLine("count = {0}", count);
            Console.WriteLine("max = {0}", max);
            Console.WriteLine("min = {0}", min); 
        }

        public void TestQueue()
        {
            Queue<string> q = new Queue<string>(new string[] { "foo", "bar", "bim" });
            q.Enqueue("pako");
            foreach (var el in q)
                Console.WriteLine(el);
            while (q.Count > 0)
                Console.WriteLine("dequeued = {0}", q.Dequeue()); 
        }

        public void TestStack()
        {
            Stack<string> stack = new Stack<string>(new string[] { "foo", "bar", "bim" });
            Console.WriteLine("stack count = {0}", stack.Count);
            foreach (var el in stack)
                Console.WriteLine(el);

            Console.WriteLine("stack peek = {0}", stack.Peek()); 
            while(stack.Count > 0)
            {
                Console.WriteLine("popped = {0}", stack.Pop()); 
            }
        }

        public void TestDictionary()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("foo", 10);
            dict.Add("bar", 20);
            dict.Add("bim", 30);

            var keys = dict.Keys;
            var values = dict.Values;
            Console.Write("keys = ");
            foreach (var key in keys)
                Console.Write("{0}, ", key);
            Console.WriteLine();
            Console.Write("values = ");
            foreach (var value in values)
                Console.Write("{0}, ", value);
            Console.WriteLine(); 

            foreach(var key in keys)
            {
                Console.WriteLine("{0}=> {1}", key, dict[key]); 
            }
            bool containsKey = dict.ContainsKey("foo");
            bool containsValue = dict.ContainsValue(23);
            Console.WriteLine("containsKey = {0}", containsKey);
            Console.WriteLine("containsValue = {0}", containsValue); 
        }

        public void TestHashSet()
        {
            HashSet<string> hs = new HashSet<string>();
            hs.Add("foo");
            hs.Add("bar");
            hs.Add("bim"); 
            foreach(var el in hs)
            {
                Console.WriteLine(el); 
            }

            bool all = hs.All(delegate (string el)
            {
                return el.Length == 3; 
            });

            bool any = hs.Any(delegate (string el)
            {
                return el.StartsWith("f"); 
            });


            string min = hs.Min();
            string max = hs.Max();

            Console.WriteLine("all = {0}", all);
            Console.WriteLine("any = {0}", any);
            Console.WriteLine("min = {0}", min);
            Console.WriteLine("max = {0}", max); 
            
        }

        public void TestLinkedList()
        {
            LinkedList<int> list = new LinkedList<int>(new int []{ 2, 3, 4, 5 });
            list.AddFirst(1);
            /*
             * that is false -> error: LinkedListNode does not belong to list
            list.AddAfter(new LinkedListNode<int>(1), 2);
            list.AddAfter(new LinkedListNode<int>(2), 3);
            list.AddAfter(new LinkedListNode<int>(3), 4);
            */
            Console.Write("linkedList = ");
            foreach (int n in list)
                Console.Write("{0}, ", n);
            Console.WriteLine();

            int sum = list.Sum();
            int max = list.Max();
            int min = list.Min();
            double avg = list.Average();
            Console.WriteLine("sum = {0}", sum);
            Console.WriteLine("min = {0}", min);
            Console.WriteLine("max = {0}", max);
            Console.WriteLine("avg = {0}", avg); 
        }
        public void TestList()
        {
            List<string> list = new List<string>();
            list.Add("foo");
            list.Add("bar");
            list.Add("bim");
            Console.Write("list: ");
            list.ForEach(delegate (string name)
            {
                Console.Write("{0}, ", name); 
            });
            Console.WriteLine();

            string first = list.First();
            string last = list.Last();
            string min = list.Min();
            string max = list.Max();

            Console.WriteLine("first = {0}", first);
            Console.WriteLine("last = {0}", last);
            Console.WriteLine("min = {0}", min);
            Console.WriteLine("max = {0}", max);

            IEnumerable<string> chosen = list.Where(delegate (string name)
            {
                return name.Length == 3; 
            });

            Console.Write("chosen = ");
            foreach (var name in chosen)
                Console.Write("{0}, ", name);
            Console.WriteLine(); 
        }
    }




}
