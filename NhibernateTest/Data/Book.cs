
namespace NhibernateTest.Data
{
    public class Book
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Type { get; set; }
        public virtual Author Author { get; set; }
        
    }

}