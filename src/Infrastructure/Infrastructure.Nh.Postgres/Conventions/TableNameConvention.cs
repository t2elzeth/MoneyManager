using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using Humanizer;

namespace Infrastructure.Nh.Postgres.Conventions;

public class TableNameConvention : IClassConvention
{
    public void Apply(IClassInstance instance)
    {
        instance.Table(instance.EntityType.Name.Underscore().Pluralize());
    }
}