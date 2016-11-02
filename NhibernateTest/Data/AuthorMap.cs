using FluentNHibernate.Mapping;

namespace NhibernateTest.Data
{
    public class AuthorMap : ClassMap<Author>
    {
        public AuthorMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            HasMany(x => x.Books).Inverse().Cascade.All().Not.LazyLoad();
        }
    }
}