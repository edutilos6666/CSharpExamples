using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection; 

namespace CSharpExamples
{
    class ReflectionExample
    {

       
        public void T2()
        {
            Type type = typeof(List<String>);
            ConstructorInfo[] constructors =  type.GetConstructors();
            object[] customAttributes = type.GetCustomAttributes(true);
            //type must be enum 
            //   string[] enumNames = type.GetEnumNames();
            EventInfo[] events = type.GetEvents();
            FieldInfo[] fields = type.GetFields();
            Type[] interfaces = type.GetInterfaces();
            Type[] nestedTypes = type.GetNestedTypes();
            MethodInfo[] methods =  type.GetMethods();

            var runtimeEvents = type.GetRuntimeEvents();
            var runtimeMethods = type.GetRuntimeMethods();
            var runtimeFields = type.GetRuntimeFields();
            var runtimeProps = type.GetRuntimeProperties();

            Console.Write("constuctors: "); 
            foreach(var con in constructors)
            {
                Console.Write("{0},", con.Name); 
            }
            Console.WriteLine();
            Console.Write("custom attrs: "); 
            foreach(var att in customAttributes)
            {
                Console.Write("{0}, ", att.ToString()); 
            }
            Console.WriteLine();
     
        }

        public void T1()
        {
            Type mi1 = typeof(SimpleAttributeTest);
            foreach(object attr in mi1.GetCustomAttributes(false))
            {
                CustomAttribute ca = (CustomAttribute)attr; 
                if(ca != null)
                {
                    Console.WriteLine("[id,author,priority] = [{0},{1},{2}]",
                        ca.Id, ca.Author, ca.Priority);  
                }
            }
        }
    }
}
