using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExamples
{
    class Box 
    {
        public double Width { get; set;  }
        public double Height { get; set;  }
        public double Depth { get; set;  }

        public Box(double width , double height , double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth; 
        }

        public Box()
        {

        }

        ~Box()
        {

        }

        public double Volume()
        {
            return Width * Height * Depth; 
        }

        public override string ToString()
        {
            return string.Format("Box({0},{1},{2})",
                Width, Height, Depth); 
        }


        public static Box operator+(Box b1 , Box b2)
        {
            Box ret = new Box();
            ret.Width = b1.Width + b2.Width;
            ret.Height = b1.Height + b2.Height;
            ret.Depth = b1.Depth + b2.Depth; 
            return ret; 
        }

        public static Box operator-(Box b1, Box b2)
        {
            Box ret = new Box();
            ret.Width = b1.Width - b2.Width;
            ret.Height = b1.Height - b2.Height;
            ret.Depth = b1.Depth - b2.Depth; 
            return ret; 
        }

        public static Box operator*(Box b1, Box b2)
        {
            Box ret = new Box();
            ret.Width = b1.Width * b2.Width;
            ret.Height = b1.Height * b2.Height;
            ret.Depth = b1.Depth * b2.Depth;
            return ret; 
        }

        public static Box operator/(Box b1, Box b2)
        {
            Box ret = new Box();
            ret.Width = b1.Width / b2.Width;
            ret.Height = b1.Height / b2.Height;
            ret.Depth = b1.Depth / b2.Depth; 
            return ret; 
        }


        public static Box operator-(Box b)
        {
            return new Box(-b.Width, -b.Height, -b.Depth); 
        }

        public static Box operator+(Box b)
        {
            return new Box(b.Width, b.Height, b.Depth); 
        }

        public static bool operator==(Box b1, Box b2)
        {
            bool ret = false;
            double v1 = b1.Volume(),
                v2 = b2.Volume();
            if (v1 == v2) ret = true; 
            return ret; 
        }


        public static bool operator!=(Box b1 , Box b2)
        {
            double v1 = b1.Volume(),
                v2 = b2.Volume();
            return v1 != v2; 
        }

        public static bool operator>(Box b1, Box b2)
        {
            return b1.Volume() > b2.Volume(); 
        }

        public static bool operator<(Box b1, Box b2)
        {
            return b1.Volume() < b2.Volume(); 
        }

        public static bool operator>=(Box b1, Box b2)
        {
            return b1.Volume() >= b2.Volume(); 
        }

        public static bool operator<=(Box b1, Box b2)
        {
            return b1.Volume() <= b2.Volume(); 
        }


    }
}
