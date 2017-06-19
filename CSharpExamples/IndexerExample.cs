using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExamples
{
    class IndexerExample
    {
        private string[] names = new string[10]; 


        public IndexerExample()
        {
          //  Console.WriteLine("names length = {0}", names.Length); 
            for(int i=0; i< names.Length; ++i)
            {
                names[i] = "N.A."; 
            }
        }

        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < names.Length)
                    return names[index];
                else throw new Exception("get index is invalid."); 
            }
            set
            {
                if (index >= 0 && index < names.Length)
                    names[index] = value;
                else throw new Exception("set index is invalid."); 
            }
        }

        public int this[string name]
        {
            get
            {
                for(int i=0; i< names.Length; ++i)
                {
                    if (names[i].Equals(name)) return i; 
                }

                return -1; 
            } 
         
        }
    }
}
