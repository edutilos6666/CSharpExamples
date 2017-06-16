using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExamples
{
    interface Shape
    {
        double Perimeter();
        double Area(); 
    }


    class Triangle : Shape
    {
        public double A { get; set;  }
        public double B { get; set;  }
        public double C { get; set;  }

        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c; 
        }

        ~Triangle()
        {

        }

        public double Area()
        {
            double ret = 0;
            double S = Perimeter() / 2;
            ret = Math.Sqrt(S * (S - A) * (S - B) * (S - C)); 
            return ret; 
        }

        public double Perimeter()
        {
            return A + B + C; 
        }

        public override string ToString()
        {
            return string.Format("Triangle({0},{1},{2})", A, B, C); 
        }

    } //end Triangle 


    class Rectangle : Shape
    {
        public double A { get; set;  }
        public double B { get; set;  }
        
        public Rectangle(double a, double b)
        {
            this.A = a;
            this.B = b;  
        }
                
        public double Area()
        {
            return A * B; 
        }

        public double Perimeter()
        {
            return 2 * (A + B); 
        }

        public override string ToString()
        {
            return string.Format("Rectangle({0},{1})", A, B); 
        }
    } //end Rectangle 


    class Circle : Shape
    {
        public double R { get; set;  }

        public Circle(double r)
        {
            this.R = r; 
        }

        public double Area()
        {
            return Math.PI * Math.Pow(R, 2); 
        }

        public double Perimeter()
        {
            return 2 * Math.PI * R; 
        }

        public override string ToString()
        {
            return string.Format("Circle({0})", R); 
        }
    }


}
