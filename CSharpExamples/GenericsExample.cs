using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExamples
{

    delegate T GenericBiOp<T>(T n1, T n2); 



    class GenericsRunner
    {
        public void T1()
        {
            GenericPerson<long, string, int, double, bool> gp1, gp2;
            gp1 = new GenericPerson<long, string, int, double, bool>(1, "foo", 10, 100.0, true);
            gp2 = new GenericPerson<long, string, int, double, bool>(2, "bar", 20, 200.0, false);
            Console.WriteLine("gp1 = {0}", gp1.ToString());
            Console.WriteLine("gp2 = {0}", gp2.ToString()); 
        }


        public void T2<L, S, I, D, B>(L id , S name , I age, D wage, B active)
        {
            Console.WriteLine("{0},{1},{2},{3},{4}", id, name, age, wage, active); 
        }


        public void T3()
        {
            GenericBiOp<double> gAdd, gSubtract, gMultiply, gDivide;
            gAdd = new GenericBiOp<double>(Add);
            gSubtract = new GenericBiOp<double>(Subtract);
            gMultiply = new GenericBiOp<double>(Multiply);
            gDivide = new GenericBiOp<double>(Divide);
            double n1 = 10, n2 = 3;
            Console.WriteLine("gAdd = {0}", gAdd(n1, n2));
            Console.WriteLine("gSubtract = {0}", gSubtract(n1, n2));
            Console.WriteLine("gMultiply = {0}", gMultiply(n1, n2));
            Console.WriteLine("gDivide = {0}", gDivide(n1, n2));


            GenericBiOp<double> gAnonym = delegate (double _n1, double _n2)
            {
                return Math.Pow(_n1, _n2); 
            };

            Console.WriteLine("gAnonym = {0}", gAnonym(n1, n2)); 
        }

        public double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public double Multiply(double n1, double n2)
        {
            return n1 * n2; 
        }

        public double Subtract(double n1, double n2)
        {
            return n1 - n2; 
        }

        public double Divide(double n1, double n2)
        {
            return n1 / n2; 
        }
    }

    class GenericPerson<L, S, I, D, B>
    {
        public L Id { get; set;  }
        public S Name { get; set;  }
        public I Age { get; set; }
        public D Wage { get; set; }
        public B Active { get; set; }
        public GenericPerson(L id , S name, I age, D wage, B active)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Wage = wage;
            this.Active = active; 
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4}", Id, Name,
                Age, Wage, Active); 
        }
    }
}
