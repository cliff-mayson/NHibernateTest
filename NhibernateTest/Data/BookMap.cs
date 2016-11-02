using FluentNHibernate.Mapping;

namespace NhibernateTest.Data
{
    public class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
            Id(x => x.Id);
            Map(x => x.Title);
            Map(x => x.Type);
            References(x => x.Author).Column("AuthorId");
        }
    }
}