using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace CSharpExamples
{
    class FileIOExample
    {

        //DirectoryInfo & FileInfo 
        public void Example5()
        {
            DirectoryInfo di = new DirectoryInfo("c:\\windows");
            FileInfo[] fileInfos = di.GetFiles(); 
            foreach(FileInfo fi in fileInfos)
            {
                string name = fi.Name;
                string dirName = fi.DirectoryName;
                string fullName = fi.FullName;
                DateTime ct = fi.CreationTime;
                DateTime la = fi.LastAccessTime;
                DateTime lw = fi.LastWriteTime;
                long length = fi.Length;
                Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}",
                    name, dirName, fullName, ct.ToString(),
                    la.ToString(), lw.ToString(), length); 
            }
        }

        //BinaryReader & BinaryWriter 
        public void Example4()
        {
            const string filename = "test4.out";
            long id = 1L;
            string name = "foo";
            int age = 10;
            double wage = 100.0D;
            bool active = true; 

            using(BinaryWriter bw = new BinaryWriter(new FileStream(filename, FileMode.Create)))
            {
                bw.Write(id);
                bw.Write(name);
                bw.Write(age);
                bw.Write(wage);
                bw.Write(active); 
            }

            using(BinaryReader br = new BinaryReader(new FileStream(filename , FileMode.Open)))
            {
                long idRead = br.ReadInt64();
                string nameRead = br.ReadString();
                int ageRead = br.ReadInt32();
                double wageRead = br.ReadDouble();
                bool activeRead = br.ReadBoolean();
                Console.WriteLine("idRead = {0}", idRead);
                Console.WriteLine("nameRead = {0}", nameRead);
                Console.WriteLine("ageRead = {0}", ageRead);
                Console.WriteLine("wageRead = {0}", wageRead);
                Console.WriteLine("activeRead = {0}", activeRead); 
            }
        }

        //StreamReader & StreamWriter 
        public void Example3()
        {
            const string filename = "test3.out"; 
            List<Person> personList = new List<Person>();
            personList.Add(new Person(1, "foo", 10, 100.0, true));
            personList.Add(new Person(2, "bar", 20, 200.0, false));
            personList.Add(new Person(3, "bim", 30, 300.0, true)); 
        
            using(StreamWriter sw = new StreamWriter(filename))
            {
                personList.ForEach(delegate (Person person)
                {
                    sw.WriteLine(person.ToString()); 
                }); 
            }

            using (StreamReader sr = new StreamReader(filename))
            {
                String line = null;
                List<Person> readPerson = new List<Person>(); 

                while((line = sr.ReadLine())!= null)
                {
                    string[] splitted = line.Split(','); 
                    try
                    {
                        long id = Convert.ToInt64(splitted[0]);
                        string name = splitted[1];
                        int age = Convert.ToInt32(splitted[2]);
                        double wage = Convert.ToDouble(splitted[3]);
                        bool active = Convert.ToBoolean(splitted[4]);
                        readPerson.Add(new Person(id, name, age, wage, active)); 
                    } catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message); 
                    }
                }

                Console.WriteLine("<<Person List>>"); 
                foreach(var p in readPerson)
                {
                    Console.WriteLine(p.ToString());
                }
            }
        }

        //StreamReader & StreamWriter 
        public void Example2()
        {
            const string filename = "test2.out"; 
            using(StreamWriter sw = new StreamWriter(filename))
            {
                List<string> names = new List<string>();
                names.Add("foo");
                names.Add("bar");
                names.Add("bim");
                names.ForEach(delegate (string name)
                {
                    sw.WriteLine(name); 
                }); 
            }


            using(StreamReader sr = new StreamReader(filename))
            {
                List<string> names = new List<string>();
                string name = null; 
                while((name = sr.ReadLine())!= null)
                {
                    names.Add(name);
                }
                
                foreach(var name2 in names)
                {
                    Console.WriteLine(name2); 
                }
            }
        }

        public void Example1()
        {
            string filename = "test.out";
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            var p1 = new Person(1L, "foo", 10, 100.0D, true);
            string str = p1.ToString();
            foreach (char ch in str)
            {
                byte b = (byte)ch;
                fs.WriteByte(b);
            }

            fs.Seek(0, SeekOrigin.Begin);
            byte[] arr = new byte[str.Length];
            fs.Read(arr, 0, arr.Length); 
            foreach(byte b in arr)
            {
                Console.Write((char)b); 
            }
            Console.WriteLine(); 
            fs.Close(); 
        }

        private class Person
        {
            public long Id { get; set;  }
            public string Name { get; set;  }
            public int Age { get; set;  }
            public double Wage { get; set;  }
            public bool Active { get; set;  }

            public Person(long id , string name, int age, double wage, bool active)
            {
                this.Id = id;
                this.Name = name;
                this.Age = age;
                this.Wage = wage;
                this.Active = active; 
            }

            public Person()
            {

            }

            public override string ToString()
            {
                return String.Format("{0},{1},{2},{3},{4}",
                    Id, Name, Age, Wage, Active); 
            }
        }

    }



  
}
