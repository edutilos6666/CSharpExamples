using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; 

namespace CSharpExamples
{
    class ThreadExample
    {
        public void T1()
        {
            ThreadStart ts = new ThreadStart(SimpleIncrement);
            Thread t1, t2;
            t1 = new Thread(ts);
            t1.Name = "foo"; 
            t2 = new Thread(ts);
            t2.Name = "bar"; 
            t1.Start();
            t2.Start();
            Thread.Sleep(200);
            t1.Abort(); 
            t1.Join();
            t2.Join(); 
        }

        private void SimpleIncrement()
        {
            string currentThreadName = Thread.CurrentThread.Name; 
            for(int i=0; i< 10; ++i)
            {
                Console.WriteLine("{0}: i = {1}", currentThreadName,  i);
                Thread.Sleep(100); 
            }
        }
    }
}
