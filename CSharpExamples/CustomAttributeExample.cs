using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExamples
{
    [AttributeUsage(AttributeTargets.Class |
        AttributeTargets.Constructor |
        AttributeTargets.Field |
        AttributeTargets.Property |
        AttributeTargets.Method, AllowMultiple =true)]
    class CustomAttribute: System.Attribute
    {
        public long Id { get; set;  }
        public string Author { get; set;  }
        public int Priority { get; set;  }

        public CustomAttribute(long id, string author , int priority)
        {
            this.Id = id;
            this.Author = author;
            this.Priority = priority; 
        }


        public override string ToString()
        {
            return string.Format("{0},{1},{2}", Id, Author, Priority);
        }
    }



    [CustomAttribute(1, "foo", 10)]
    [Custom(1, "new_foo", 100)]
    class SimpleAttributeTest
    {

        [CustomAttribute(0, "foo", 10)]
        public SimpleAttributeTest()
        {

        }

        [CustomAttribute(2, "bar", 20)]
        public void t1()
        {

        }

        [Custom(3, "bim", 30)]
        private long prop1; 
        [Custom(4, "pako", 40)]
        public long Prop2 { get; set;  }
    }
}
