using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExamples
{
    class Worker
    {
        public long Id { get; set;  }
        public String Name { get; set;  }
        public int Age { get; set;  }
        public double Wage { get; set;  }
        public bool Active { get; set;  }

        public Worker(long id , string name, int age , double wage, bool active)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Wage = wage;
            this.Active = active; 
        }

        ~Worker()
        {

        }

        public override string ToString()
        {
            return String.Format("[{0}, {1}, {2}, {3}, {4}]",
                Id, Name, Age, Wage, Active); 
        }
    }
}
