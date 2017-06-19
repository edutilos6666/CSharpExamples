using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO; 

namespace CSharpExamples
{
    class XmlExample
    {
        public void T1()
        {
            string filename = "WorkerXml.xml"; 
            WriteXml(filename);
            ReadXml(filename); 
        }

        public void ReadXml(string filename)
        {
            List<WorkerXml> list = new List<WorkerXml>();

            // XmlTextReader reader = new XmlTextReader(new FileStream(filename, FileMode.Open, FileAccess.Read), null);
            XmlTextReader reader = new XmlTextReader(filename);
            long _id = 0;
            string _name = "";
            int _age = 0;
            double _wage = 0.0;
            bool _active = false;

            while (reader.Read())
            {
              
                XmlNodeType nodeType = reader.NodeType;
               
                if(nodeType == XmlNodeType.Element)
                {
                    string name = reader.Name;
                    //Console.WriteLine(name);
                    if (name.Equals("Worker"))
                        _id = Convert.ToInt64(reader.GetAttribute("id"));
     
                       


                    if (name.Equals("Name") || name.Equals("Age") || name.Equals("Wage") || name.Equals("Active"))
                    {
                        while (nodeType != XmlNodeType.Text)
                        {
                            reader.Read();
                            nodeType = reader.NodeType;
                        }
                    }
                    if (reader.Value == "") continue; 
           
                   switch(name)
                    {
                        case "Name":
                            _name = reader.Value;
  
                            break;
                        case "Age":
                            _age = Convert.ToInt32(reader.Value);
                          
                            break;
                        case "Wage":
                            _wage = Convert.ToDouble(reader.Value);
                         
                            break;
                        case "Active":
                            _active = Convert.ToBoolean(reader.Value);
            
                            list.Add(new WorkerXml(_id, _name, _age, _wage, _active));
                            break; 
                    }
                }
            }
            reader.Close();

            Console.WriteLine("<<all workerXml-s>>");
            foreach (var worker in list)
                Console.WriteLine(worker.ToString()); 
        }

        public void WriteXml(string filename)
        {
            List<WorkerXml> list = new List<WorkerXml>();
            list.Add(new WorkerXml(1, "foo", 10, 100.0, true));
            list.Add(new WorkerXml(2, "bar", 20, 200.0, false));
            list.Add(new WorkerXml(3, "bim", 30, 300.0, true));


            XmlTextWriter writer = new XmlTextWriter(new FileStream(filename, FileMode.Create ,  FileAccess.Write), null);
            writer.Formatting = Formatting.Indented; 
            writer.WriteStartDocument(); 
            writer.WriteStartElement("Workers", null);
            writer.WriteComment("simple comment");
            foreach (var worker in list)
            {
                writer.WriteStartElement("Worker");
                //id 
                /*
                writer.WriteStartElement("id", null);
                writer.WriteString(Convert.ToString(worker.Id));
                writer.WriteEndElement();
                */
                writer.WriteAttributeString("id", Convert.ToString(worker.Id)); 
                //name 
                writer.WriteStartElement("Name", null);
                writer.WriteString(worker.Name);
                writer.WriteEndElement();
                //age 
                writer.WriteStartElement("Age", null);
                writer.WriteString(Convert.ToString(worker.Age));
                writer.WriteEndElement();
                //wage 
                writer.WriteStartElement("Wage");
                writer.WriteString(Convert.ToString(worker.Wage));
                writer.WriteEndElement();
                //active 
                writer.WriteStartElement("Active");
                writer.WriteString(Convert.ToString(worker.Active));
                writer.WriteEndElement();
                writer.WriteEndElement(); 
            }


            writer.WriteEndElement(); 
            writer.WriteEndDocument();
            writer.Flush(); 
            writer.Close(); 
        }


    }

    class  WorkerXml
    {
        public long Id { get; set;  }
        public string Name { get; set;  }
        public int Age { get; set;  }
        public double Wage { get; set;  }
        public bool Active { get; set;  }

        public WorkerXml(long id, string name, int age, double wage, bool active)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Wage = wage;
            this.Active = active; 
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4}", Id, Name, Age, Wage, Active); 
        }
    }
}
