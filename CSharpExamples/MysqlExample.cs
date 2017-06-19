using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; 

namespace CSharpExamples
{
    class MysqlExample
    {
        public void T1()
        {
            WorkerDAO dao = new WorkerDAOImpl();
            ((WorkerDAOImpl)dao).Connect();
            ((WorkerDAOImpl)dao).CreateDatabase();
            ((WorkerDAOImpl)dao).CreateTable();
            List<MysqlWorker> list = new List<MysqlWorker>();
            list.Add(new MysqlWorker("foo", 10, 100.0, true));
            list.Add(new MysqlWorker("bar", 20, 200.0, false));
            list.Add(new MysqlWorker("bim", 30, 300.0, true)); 
            foreach(MysqlWorker worker in list)
            {
                dao.Save(worker); 
            }

            Console.WriteLine("<<all workers>>");
            var all = dao.FindAll(); 
            foreach(var worker in all)
            {
                Console.WriteLine(worker.ToString()); 
            }
            Console.WriteLine();


            //update 
            dao.Update(1L, new MysqlWorker(1L, "new_foo", 66, 666.6, false));
            var one = dao.FindById(1L);
            Console.WriteLine("after update = {0}", one.ToString());

            //remove 
            dao.Remove(1L);
            all = dao.FindAll();
            Console.WriteLine("after remove table size = {0}", all.Count); 

            ((WorkerDAOImpl)dao).DropDatabase();
            ((WorkerDAOImpl)dao).Disconnect();
        }
    }



    interface WorkerDAO
    {
        void Save(MysqlWorker worker);
        void Update(long id, MysqlWorker newWorker);
        void Remove(long id);
        MysqlWorker FindById(long id);
        List<MysqlWorker> FindAll(); 
    }

    class WorkerDAOImpl : WorkerDAO
    {
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataReader reader; 
        private string sql;
        private const string URL = @"server=localhost;userid=root;"; 
        public void Connect()
        {
            try
            {
                conn = new MySqlConnection(URL);
                conn.Open();
                Console.WriteLine("connection success."); 
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }

        public void Disconnect()
        {
            conn.Close(); 
        }

        public void CreateDatabase()
        {
            sql = "create database testCSharp";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteScalar();
            sql = "use testCSharp";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteScalar(); 
        }
        public void DropDatabase()
        {
            sql = "drop database testCSharp";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteScalar(); 
        }
        public void CreateTable()
        {
            sql = @"create table Worker (
id bigint primary key auto_increment , 
name varchar(50) not null , 
age int not null , 
wage double not null , 
active boolean not null 
)";


            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteScalar(); 
        }

        private MysqlWorker MapReaderToWorker(MySqlDataReader reader)
        {
            MysqlWorker ret = null; 
            long _id = reader.GetInt64("id");
            string _name = reader.GetString("name");
            int _age = reader.GetInt32("age");
            double _wage = reader.GetDouble("wage");
            bool _active = reader.GetBoolean("active");
            ret = new MysqlWorker(_id, _name, _age, _wage, _active);
            return ret; 
        }
        public List<MysqlWorker> FindAll()
        {
            List<MysqlWorker> ret = new List<MysqlWorker>();
            sql = "select * from Worker";
            cmd = new MySqlCommand(sql, conn);
            reader = cmd.ExecuteReader(); 
            while(reader.Read())
            {
                ret.Add(MapReaderToWorker(reader)); 
            }

            reader.Close(); 
            return ret; 
        }

        public MysqlWorker FindById(long id)
        {
            MysqlWorker ret = null;
            sql = @"select * from Worker where id = @id";
            cmd = new MySqlCommand(sql, conn);
            cmd.Prepare(); 
            cmd.Parameters.AddWithValue("@id", id);
            reader = cmd.ExecuteReader(); 
            while(reader.Read())
            {
                ret = MapReaderToWorker(reader); 
            }

            reader.Close(); 
            return ret; 
        }

        public void Remove(long id)
        {
            sql = "delete from Worker where id = @id";
            cmd = new MySqlCommand(sql, conn);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery(); 
        }

        public void Save(MysqlWorker worker)
        {
            sql = @"insert into Worker (name , age, wage, active) 
VALUES(@name, @age, @wage, @active) ";
            cmd = new MySqlCommand(sql, conn);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@name", worker.Name);
            cmd.Parameters.AddWithValue("@age", worker.Age);
            cmd.Parameters.AddWithValue("@wage", worker.Wage);
            cmd.Parameters.AddWithValue("@active", worker.Active);

            cmd.ExecuteNonQuery();  
             
        }

        public void Update(long id, MysqlWorker newWorker)
        {
            sql = @"update Worker set name = @name , age = @age , 
wage = @wage, active = @active where id = @id";
            cmd = new MySqlCommand(sql, conn);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@name", newWorker.Name); 
            cmd.Parameters.AddWithValue("@age", newWorker.Age);
            cmd.Parameters.AddWithValue("@wage", newWorker.Wage);
            cmd.Parameters.AddWithValue("@active", newWorker.Active);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery(); 
        }
    }


    class MysqlWorker
    {
        public long Id { get; set;  }
        public string Name { get; set;  }
        public int Age { get; set;  }
        public double Wage { get; set;  }
        public bool Active { get; set;  }

        public MysqlWorker(long id, string name, int age, double wage, bool active)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Wage = wage;
            this.Active = active; 
        }


        public MysqlWorker(string name, int age, double wage, bool active)
        {
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
