using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExamples
{
    struct Book
    {
        public long Id { get; set;  }
        public string Title { get; set;  }
        public string Subject { get; set;  }
        public string Author { get; set;  }

        public Book(long id , string title, string subject , string author)
        {
            Id = id;
            Title = title;
            Subject = subject;
            Author = author; 
        }

   
        private const string newline = "\r\n"; 
        public override string ToString()
        {
            return string.Format("[{0}, {1}, {2}, {3}]",
                Id, Title, Subject, Author); 
        }


        public static void PrintBook(Book book)
        {
            long id = book.Id;
            string title = book.Title;
            string subject = book.Subject;
            string author = book.Author;
            string msg = string.Format("id = {0}{1}", id, newline) +
                string.Format("title = {0}{1}", title, newline) +
                string.Format("subject = {0}{1}", subject, newline) +
                string.Format("author = {0}{1}", author, newline);
            Console.WriteLine(msg); 
        }

    }
}
