using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExamples
{
    class SimpleMath
    {
        public Double N1 { get; set;  }
        public Double N2 { get; set;  }

        public SimpleMath(double n1 , double n2)
        {
            this.N1 = n1;
            this.N2 = n2; 
        }

        public double Add()
        {
            return N1 + N2; 
        }

        public double Subtract()
        {
            return N1 - N2; 
        }
        
        public double Multiply()
        {
            return N1 * N2; 
        }

        public double Divide()
        {
            return N1 / N2; 
        }
        public double Modulo()
        {
            return N1 % N2; 
        }
    }
}
