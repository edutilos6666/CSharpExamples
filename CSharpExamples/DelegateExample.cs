using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace CSharpExamples
{
    delegate double BinaryOperator(double n1, double n2);
    delegate double UnaryOperator(double n);
    delegate void CustomStringWriter(string str);
    
    class DelegateExample
    {

       // delegate double test(double n); 

        public void T1()
        {
            BinaryOperator boAdd = new BinaryOperator(Add);
            BinaryOperator boSubtract = new BinaryOperator(Subtract);
            BinaryOperator boMultiply = new BinaryOperator(Multiply);
            BinaryOperator boDivide = new BinaryOperator(Divide);

            double n1 = 10, n2 = 3;
            Console.WriteLine("boAdd = {0}", boAdd(n1, n2));
            Console.WriteLine("boSubtract = {0}", boSubtract(n1, n2));
            Console.WriteLine("boMultiply = {0}", boMultiply(n1, n2));
            Console.WriteLine("boDivide = {0}", boDivide(n1, n2)); 
        }

        public void T2()
        {
            UnaryOperator uAdd = new UnaryOperator(SingleAdd),
                uSubtract = new UnaryOperator(SingleSubtract),
                uMultiply = new UnaryOperator(SingleMultiply),
                uDivide = new UnaryOperator(SingleDivide);

            UnaryOperator uMulticast = uAdd + uMultiply + uSubtract + uDivide;
            double n = 10;
            Console.WriteLine("uMulticast = {0}", uMulticast(n)); 
        }


        private void SendString(CustomStringWriter csw, string str)
        {
            csw(str); 
        }
        public void T3()
        {
            CustomStringWriter csw1, csw2;
            csw1 = new CustomStringWriter(PrintToScreen);
            csw2 = new CustomStringWriter(PrintToFile);
            List<string> strs = new List<string>();
            strs.Add("foo");
            strs.Add("bar");
            strs.Add("bim");
            strs.Add("pako"); 
            foreach(var str in strs)
            {
                SendString(csw1, str);
                SendString(csw2, str); 
            }
        }

        //event example 
        event BinaryOperator boEvent;
        public void T4()
        {
            boEvent += new BinaryOperator(Add);
            boEvent += new BinaryOperator(Multiply);
            boEvent += new BinaryOperator(Subtract);
            boEvent += new BinaryOperator(Divide);
            double n1 = 10, n2 = 3;
            Console.WriteLine("boEvent = {0}", boEvent(n1, n2));

            Console.WriteLine();
            boEvent -= new BinaryOperator(Add);
            Console.WriteLine("boEvent = {0}", boEvent(n1, n2));
            Console.WriteLine();

            boEvent -= new BinaryOperator(Divide);
            Console.WriteLine("boEvent = {0}", boEvent(n1, n2));
            Console.WriteLine(); 
        }


        //printing to different devices 
        public void PrintToScreen(string str)
        {
            Console.WriteLine(str); 
        }

        public void PrintToFile(string str)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream("testDelegate.out", FileMode.Append, FileAccess.Write)))
            {
                sw.WriteLine(str);
                sw.Flush(); 
            }
        }

        //for multicasting 
        private double ret = 10 ; 
        public double SingleAdd(double n)
        {
            ret += n;
            return ret; 
        }

        public double SingleSubtract(double n)
        {
            ret -= n;
            return ret; 
        }

        public double SingleMultiply(double n)
        {
            ret *= n;
            return ret; 
        }

        public double SingleDivide(double n)
        {
            ret /= n;
            return ret; 
        }


        public double Add(double n1 , double n2)
        {
            Console.WriteLine("Add was invoked."); 
            return n1 + n2; 
        }

        public  double Multiply(double n1, double n2)
        {
            Console.WriteLine("Multiply was invoked.");
            return n1 * n2; 
        }

        public  double Subtract(double n1, double n2)
        {
            Console.WriteLine("Subtract was invoked.");
            return n1 - n2;   
        }

        public  double Divide(double n1, double n2)
        {
            Console.WriteLine("Divide was invoked.");
            return n1 / n2; 
        }
    }
}
