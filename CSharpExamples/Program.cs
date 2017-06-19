using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions; 

namespace CSharpExamples
{

    enum WeekDays
    {
        Sunday , 
        Monday ,
        Tuesday , 
        Wednesday , 
        Thursday , 
        Friday , 
        Saturday 
    }

    class Program
    {
        static void Main(string[] args)
        {
            TestStringBuilder(); 
        }

        private const string newline = "\r\n"; 
        private static Random rand = new Random();



        private static void TestStringBuilder()
        {
            const string newline = "\r\n"; 

            StringBuilder sb = new StringBuilder();
            sb.Append("foo").Append(newline)
                .Append("bar").Append(newline)
                .Append("bim").Append(newline);
            Console.WriteLine(sb.ToString()); 
        }

        private static void TestGenericCollections()
        {
            GenericCollections gc = new GenericCollections();
            gc.TestSortedSet(); 
        }

        private static void TestMysqlExample()
        {
            MysqlExample me = new MysqlExample();
            me.T1(); 
        }

        private static void TestXmlExample()
        {
            XmlExample xe = new XmlExample();
            xe.T1(); 
        }

        private static void TestThreadExample()
        {
            ThreadExample te = new ThreadExample();
            te.T1(); 
        }

        private static void TestGenericsExample()
        {
            GenericsRunner runner = new GenericsRunner();
            // runner.T2<long, string ,int, double, bool>(1L, "foo", 10, 100.0, true); 
            runner.T3(); 
        }

        private static void TestCollectionsExample()
        {
            CollectionsExample ce = new CollectionsExample();
            ce.TestBitArray(); 
        }

        private static void TestDelegateExample()
        {
            DelegateExample de = new DelegateExample();
            de.T4(); 
        }

        private static void TestIndexerExample()
        {
            IndexerExample ie = new IndexerExample(); 
            for(int i=0; i< 10; ++i)
            {
                ie[i] = "foo " + i; 
            }

            Console.WriteLine("<<Indexer Values>>"); 
            for(int i=0; i< 10; ++i)
            {
                Console.WriteLine("{0}", ie[i]); 
            }

            string searchStr = "foo 1";
            Console.WriteLine("index of {0} = {1}", searchStr, ie[searchStr]); 
        }


        private static void TestReflectionExample()
        {
            ReflectionExample re = new ReflectionExample();
            re.T2(); 
        }


        [Obsolete("Use NewMethod instead", false)]
        private static void OldMethod()
        {
            Console.WriteLine("OldMethod was invoked."); 
        }

        private static void NewMethod()
        {
            Console.WriteLine("NewMethod was invoked."); 
        }

        private static void TestDateTime()
        {
            DateTime dt = DateTime.Now;
            PrintDateTime(dt); 
            dt = new DateTime(1991, 12, 8, 10, 10, 10);
            PrintDateTime(dt);

            dt = dt.AddYears(1)
                .AddMonths(1)
                .AddDays(1)
                .AddHours(1)
                .AddMinutes(1)
                .AddSeconds(1);

            PrintDateTime(dt); 
        }

        private static void PrintDateTime(DateTime dt)
        {
            int year = dt.Year;
            int month = dt.Month;
            int day = dt.Day;
            int hour = dt.Hour;
            int minute = dt.Minute;
            int second = dt.Second;
            Console.WriteLine("{0}-{1}-{2} time: {3}:{4}:{5}",
                year, month, day, hour, minute, second);
        }


        private static void TestRegexp()
        {
            string pattern = "\\s+"; 
            Regex regex = new Regex(pattern);
            string input = "Hello     World";
            string replacement = " ";
            string output = regex.Replace(input, replacement);
            Console.WriteLine("input length = {0}", input.Length);
            Console.WriteLine("output length = {0}", output.Length);


            input = "foo bar foobimfoo";
            pattern = "foo"; 
            MatchCollection matches = Regex.Matches(input, pattern); 
            foreach(var match in matches)
            {
                Console.WriteLine(match); 
            }
        }

        private static void TestFileIOExample()
        {
            FileIOExample io = new FileIOExample();
            //io.Example1();
            io.Example5(); 
        }


        private static void TestOperatorOverloading()
        {
            Box b1 = new Box(1, 1, 1);
            Box b2 = new Box(2, 2, 2);
            Console.WriteLine("b1 == b2 = {0}", b1 == b2);
            Console.WriteLine("b1 != b2 = {0}", b1 != b2);
            Console.WriteLine("b1 > b2 = {0}", b1 > b2);
            Console.WriteLine("b1 >= b2 = {0}", b1 >= b2);
            Console.WriteLine("b1 < b2 = {0}", b1 < b2);
            Console.WriteLine("b1 <= b2 = {0}", b1 <= b2);
            Box add = b1 + b2,
                subtract = b2 - b1,
                multiply = b1 * b2,
                divide = b2 / b1;

            Console.WriteLine("add = {0}", add);
            Console.WriteLine("subtract = {0}", subtract);
            Console.WriteLine("multiply = {0}", multiply);
            Console.WriteLine("divide = {0}", divide); 
        }

        private static void TestShape()
        {
            Shape s1, s2, s3;
            s1 = new Triangle(10, 11, 12);
            s2 = new Rectangle(10, 20);
            s3 = new Circle(10);
            PrintShape(s1);
            Console.WriteLine(); 
            PrintShape(s2);
            Console.WriteLine(); 
            PrintShape(s3);
            Console.WriteLine(); 
        }

        private static void PrintShape(Shape shape)
        {
            Console.WriteLine(shape.ToString());
            double perimeter = shape.Perimeter(),
                area = shape.Area();

            Console.WriteLine("Perimeter = {0}{1}Area = {2}",
                perimeter, newline, area); 
        }

        private static void TestWeekDays()
        {
            Console.WriteLine("monday = {0}", WeekDays.Monday.ToString());

            WeekDays monday = WeekDays.Monday; 
            switch(monday)
            {
                case WeekDays.Monday:
                    Console.WriteLine("hello Monday");
                    break;
                case WeekDays.Tuesday:
                    Console.WriteLine("hello Tuesday");
                    break;
                case WeekDays.Wednesday:
                    Console.WriteLine("hello Wednesday");
                    break;
                case WeekDays.Thursday:
                    Console.WriteLine("hello Thursday");
                    break;
                case WeekDays.Friday:
                    Console.WriteLine("hello Friday");
                    break;
                case WeekDays.Saturday:
                    Console.WriteLine("hello Saturday");
                    break;
                case WeekDays.Sunday:
                    Console.WriteLine("hello Sunday");
                    break; 
            } 
        }

        private static void TestBook()
        {
            Book b1 = new Book(1, "foo", "bar", "bim");
            Console.WriteLine(b1.ToString());
            b1.Title = "new_foo";
            Book.PrintBook(b1);  
        }

        private static void TestString()
        {
            String str = "foobar";
            bool contains = str.Contains("foo");
            bool startsWith = str.StartsWith("foo");
            bool endsWith = str.EndsWith("bar");
            str.Trim();
            str.TrimStart();
            str.TrimEnd();
            str.ToLower();
            str.ToLowerInvariant();
            str.ToUpper();
            str.ToUpperInvariant();
            string reversed = str.Reverse() as String;
            string replaced = str.Replace('o', 'O');
            string padded = str.PadLeft(str.Length + 10);
            padded = str.PadRight(str.Length + 10);
            int index = str.IndexOf('a');
            index = str.LastIndexOf('a');
            int anyIndex = str.IndexOfAny(new char[] { 'a', 'b', 'c' });
            anyIndex = str.LastIndexOfAny(new char[] { 'a', 'b', 'c' });

            string formatted = string.Format("{0}{1}{2}", "foo", 10, 100.0);

            string[] splitted = "foo,bar,bim".Split(',');
            string joined = string.Join(" , ", "foo", "bar", "bim", 10, true);
            bool equals = string.Equals("foo", "Foo");
            equals = string.ReferenceEquals("foo", "bar");
            equals = "foo".Equals("bar", StringComparison.InvariantCultureIgnoreCase);

            int compare = "foo".CompareTo("Foo");
            compare = string.Compare("foo", "Foo");

            string substring = "foo bar bim".Substring(0, 3); 
        }

        private static void TestArray()
        {
            int[] numbers = new int[10];
            for(int i = 0; i< numbers.Length; ++i)
            {
                numbers[i] = rand.Next(0, 100); 
            }

            Console.WriteLine("<<numbers>>"); 
            foreach(int number in numbers) {
                Console.WriteLine(number); 
            }

            Console.WriteLine("numbers length = "+ numbers.GetLength(0));

            int[][] numbers2 = new int[3][];
            Console.WriteLine("numbers2 length 0 = " + numbers2.GetLength(0)); 

            for(int i=0; i< numbers2.GetLength(0); ++i)
            {
                numbers2[i] = new int[10 + i]; 
            }

            //error 
            //  Console.WriteLine("numbers2 length 1 = " + numbers2.GetLength(1)); 

            int[,] numbers3 = new int[10, 4];
            Console.WriteLine(numbers3.GetLength(0) + " " + numbers3.GetLength(1));

            numbers2[0] = new int[5]
            {
                1, 2, 3, 4, 5
            }; 
            foreach(int n in numbers2[0])
            {
                Console.Write(n + " ; "); 
            }

            Console.WriteLine();


            numbers2[1] = new int[6]
            {
                rand.Next(100), 
                rand.Next(100), 
                rand.Next(100), 
                rand.Next(100), 
                rand.Next(100), 
                rand.Next(100)
            };


            numbers2[2] = new int[4]
            {
                rand.Next(100),
                rand.Next(100),
                rand.Next(100),
                rand.Next(100)
            }; 

            for(int i = 0; i< numbers2.GetLength(0); ++i)
            {
                foreach(int n in  numbers2[i])
                {
                    Console.Write(n + " ; "); 
                }
                Console.WriteLine(); 
            }


            Console.WriteLine(); 
            for(int i =0; i< numbers3.GetLength(0); ++i)
            {
                for(int j= 0; j< numbers3.GetLength(1); ++j)
                {
                    numbers3[i, j] = rand.Next(100); 
                }
            }


            for(int i=0; i< numbers3.GetLength(0); ++i)
            {
                for(int j=0; j< numbers3.GetLength(1); ++j)
                {
                    Console.Write(numbers3[i, j] + " , "); 
                }
                Console.WriteLine(); 
            }

            Console.WriteLine();
            Print2DimArray(numbers3);

            Console.WriteLine();
            PrintJaggedArray(numbers2);
            PrintVarags(1, 2, 3, 4, 5); 
        }


        private static void PrintVarags(params int[] args)
        {
            for(int i=0; i < args.GetLength(0); ++i)
            {
                Console.Write(args[i] + " ; "); 
            }
            Console.WriteLine("\nAnd");
            foreach(int n in args)
            {
                Console.Write(n + " ; "); 
            }
            Console.WriteLine(); 
        }

        private static void PrintJaggedArray(int [][] arr)
        {
            for(int i=0; i< arr.GetLength(0); ++i)
            {
                foreach(int n in arr[i])
                {
                    Console.Write(n + " ; "); 
                }
                Console.WriteLine(); 
            }
        }

        private static void Print2DimArray(int [,] arr)
        {
            for(int i=0; i< arr.GetLength(0); ++i)
            {
                for(int j=0; j < arr.GetLength(1); ++j)
                {
                    Console.Write(arr[i, j] + " , "); 
                }

                Console.WriteLine(); 
            }
        }


        private static double generateRandomDouble(int lower, int upper)
        {
            return rand.NextDouble() * (upper - lower) + lower; 
        }


        private static void TestLoop()
        {
            int age = 10; 
            //while 
            while(age > 0 )
            {
                Console.WriteLine("Age  = " + age);
                --age; 
            }
            Console.WriteLine(); 
            //do while 
            age = 10;
            do
            {
                Console.WriteLine("Age = " + age);
                --age;
            } while (age > 0);
            Console.WriteLine();

            //for 
            age = 10; 
            for(int i=1; i<= age; ++i)
            {
                Console.WriteLine("Age = " + i); 
            }
            Console.WriteLine(); 
        }

        private static void TestControl()
        {
            int age = 10; 
            if(age < 10)
            {
                Console.WriteLine("You are very very young!"); 
            } else if(age >= 10 && age < 20)
            {
                Console.WriteLine("You are verya young!");
            } else
            {
                Console.WriteLine("You are young!"); 
            }


            switch(age)
            {
                case 5:
                    Console.WriteLine("Your age is 5.");
                    break;
                case 10:
                    Console.WriteLine("Your age is 10.");
                    break;
                case 15:
                    Console.WriteLine("Your age is 15.");
                    break;
                default:
                    Console.WriteLine("Your age is unknown to the system.");
                    break; 
            }
        }

        private static void TestUserInput()
        {
            long id;
            string name;
            int age;
            double wage;
            bool active; 

            try
            {
                Console.WriteLine("Insert id: ");
                id = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Insert name: ");
                name = Console.ReadLine();
                Console.WriteLine("Insert age: ");
                age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Insert wage: ");
                wage = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Insert active: ");
                active = Convert.ToBoolean(Console.ReadLine());

                string ret = string.Format("id = {0}{1}", id, newline) +
                    string.Format("name = {0}{1}", name, newline) +
                    string.Format("age = {0}{1}", age, newline) +
                    string.Format("wage = {0}{1}", wage, newline) +
                    string.Format("active = {0}{1}", active, newline);

                Console.WriteLine(ret); 
            } catch(Exception ex )
            {
                Console.WriteLine(ex.Message); 
            }
        }

        private static void TestSimpleMath()
        {
            SimpleMath sm = new SimpleMath(10, 3);
            double add = sm.Add(),
                subtract = sm.Subtract(),
                multiply = sm.Multiply(),
                divide = sm.Divide(),
                modulo = sm.Modulo();

            string ret = string.Format("add = {0}{1}", add, newline) +
                string.Format("subtract = {0}{1}", subtract, newline) +
                string.Format("multiply = {0}{1}", multiply, newline) +
                string.Format("divide = {0}{1}", divide, newline) +
                string.Format("modulo = {0}{1}", modulo, newline); 

            Console.WriteLine(ret); 
        }
        private static void TestWorker()
        {
            Worker w1 = new Worker(1, "foo", 10, 100.0, true);
            Console.WriteLine(w1.ToString());
            w1.Name = "new_foo";
            Console.WriteLine(w1.ToString());
            w1.Age = 66;
            Console.WriteLine(w1.ToString()); 
        }
    }
}
