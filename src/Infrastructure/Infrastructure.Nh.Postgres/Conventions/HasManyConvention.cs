using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using Humanizer;

namespace Infrastructure.Nh.Postgres.Conventions;

public class HasManyConvention : IHasManyConvention
{
    public void Apply(IIdentityInstance instance)
    {
        instance.Column(instance.Name.Underscore());
    }

    public void Apply(IOneToManyCollectionInstance instance)
    {
        instance.Inverse();
        instance.LazyLoad();
        instance.Cascade.SaveUpdate();
        instance.Fetch.Select();
    }
}