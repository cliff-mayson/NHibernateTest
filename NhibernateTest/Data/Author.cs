using System.Collections.Generic;

namespace NhibernateTest.Data
{
    public class Author
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual IList<Book> Books { get; set; }


        public Author()
        {
            Books = new List<Book>();
        }
    }
}