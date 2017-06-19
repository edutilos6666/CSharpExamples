using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; 

namespace CSharpExamples
{
    class CollectionsExample
    {

        public void TestBitArray()
        {
            byte[] a = { 60 };
            byte[] b = { 13 };
            BitArray ba1 = new BitArray(a);
            BitArray ba2 = new BitArray(b);

            Console.Write("ba1: "); 
            foreach(var el in ba1)
            {
                Console.Write("{0}, ", el); 
            }
            Console.WriteLine();
            Console.Write("ba2: "); 
            foreach(var el in ba2)
            {
                Console.Write("{0}, ", el); 
            }
            Console.WriteLine();

            BitArray baAnd = ba1.And(ba2);
            ba1 = new BitArray(a);
            BitArray baOr = ba1.Or(ba2);
            ba1 = new BitArray(a);
            BitArray baXor = ba1.Xor(ba2);
            ba1 = new BitArray(a);
            BitArray ba1Not = ba1.Not();
            ba1 = new BitArray(a);
            Console.Write("baAnd: ");
            foreach (var el in baAnd)
                Console.Write("{0}, ", el);
            Console.WriteLine();
            Console.Write("baOr: ");
            foreach (var el in baOr)
                Console.Write("{0}, ", el);
            Console.WriteLine();
            Console.Write("baXor: ");
            foreach (var el in baXor)
                Console.Write("{0}, ", el);
            Console.WriteLine();
            Console.Write("baNot: ");
            foreach (var el in ba1Not)
                Console.Write("{0}, ", el);
            Console.WriteLine(); 
        }

        public void TestQueue()
        {
            Queue queue = new Queue();
            queue.Enqueue("foo");
            queue.Enqueue("bar");
            queue.Enqueue("bim"); 

            foreach(var el in queue)
            {
                Console.WriteLine(el); 
            }

            Console.WriteLine(); 

            while(queue.Count > 0 )
            {
                Console.WriteLine("dequeued = {0}", queue.Dequeue()); 
            }
            Console.WriteLine(); 
        }
        public void TestStack()
        {
            Stack stack = new Stack();
            stack.Push("foo");
            stack.Push("bar");
            stack.Push("bim");

            foreach (var el in stack)
                Console.WriteLine(el);
            Console.WriteLine();

            Console.WriteLine("peek = {0}", stack.Peek()); 

            while(stack.Count > 0)
            {
                Console.WriteLine("popped = {0}", stack.Pop()); 
            }
            
        }

        public void TestSortedList()
        {
            SortedList table = new SortedList();
            table.Add("foo", 10);
            table.Add("bar", 20);
            table.Add("bim", 30);
            table.Add("pako", 40);

            ICollection keys = table.Keys;
            ICollection values = table.Values;
            Console.WriteLine("Count = {0}", table.Count);
            Console.Write("keys: ");
            foreach (var key in keys)
                Console.Write("{0}, ", key);
            Console.WriteLine();
            Console.Write("values: ");
            foreach (var value in values)
                Console.Write("{0}, ", value);
            Console.WriteLine();

            IList keyList = table.GetKeyList();
            IList valueList = table.GetValueList(); 
            foreach(var key in keyList)
            {
                Console.WriteLine("{0} => {1}", key, table[key]); 
            }
        }

        public void TestHashtable()
        {
            Hashtable table = new Hashtable();
            table.Add("foo", 10);
            table.Add("bar", 20);
            table.Add("bim", 30);
            table.Add("pako", 40);

            ICollection keys = table.Keys;
            ICollection values = table.Values;
            Console.Write("keys: ");
            foreach (var key in keys)
                Console.Write("{0}, ", key);
            Console.WriteLine();
            Console.Write("values: ");
            foreach (var value in values)
                Console.Write("{0}, ", value);
            Console.WriteLine();

            Console.WriteLine("containsKey foo = {0}", table.ContainsKey("foo"));
            Console.WriteLine("containsValue 24 = {0}", table.ContainsValue(25));


            table.Remove("foo");
            Console.WriteLine("keys Length = {0}", table.Keys.Count); 
        }

        public void TestArrayList()
        {
            ArrayList list = new ArrayList();
            /*
            //sorting is not supported for string and numeric data types mixed.
            list.Add(1L);
            list.Add("foo");
            list.Add(10);
            list.Add(100.0);
            list.Add(true);
            */
            list.Add(10D);
            list.Add(5D);
            list.Add(100D);
            list.Add(3D); 
            Console.WriteLine("count = {0}", list.Count);
            Console.WriteLine("Capacity = {0}", list.Capacity);
            Console.Write("all elements: ");
            foreach (object item in list)
                Console.Write("{0}, ", item);
            Console.WriteLine();

            list.Reverse();
            Console.Write("revesed: ");
            foreach (object item in list)
                Console.Write("{0}, ", item);
            Console.WriteLine();
            list.Sort();
            Console.Write("sorted: ");
            foreach (object item in list)
                Console.Write("{0}, ", item);
            Console.WriteLine();   
        }
    }
}
