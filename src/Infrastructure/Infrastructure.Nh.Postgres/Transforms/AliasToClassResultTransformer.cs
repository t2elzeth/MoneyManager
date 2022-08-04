using System;
using System.Collections;
using System.Reflection;
using Humanizer;
using NHibernate;
using NHibernate.Properties;
using NHibernate.Transform;

namespace Infrastructure.Nh.Postgres.Transforms;

public class AliasToClassResultTransformer : IResultTransformer
{
    private const BindingFlags Flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

    private readonly Type _resultClass;
    private ISetter[]? _setters;
    private readonly IPropertyAccessor _propertyAccessor;
    private readonly ConstructorInfo _constructor;

    public AliasToClassResultTransformer(Type resultClass)
    {
        _resultClass = resultClass;

        _constructor = resultClass.GetConstructor(Flags, null, Type.EmptyTypes, null)!;

        if (_constructor == null && resultClass.IsClass)
        {
            throw new ArgumentException("The target class of a AliasToBeanResultTransformer need a parameter-less constructor",
                                        nameof(resultClass));
        }

        _propertyAccessor = new ChainedPropertyAccessor(new[]
        {
            PropertyAccessorFactory.GetPropertyAccessor(null),
            PropertyAccessorFactory.GetPropertyAccessor("field")
        });
    }

    public object TransformTuple(object[] tuple, string[] aliases)
    {
        if (aliases == null)
            throw new ArgumentNullException(nameof(aliases));

        object result;
        try
        {
            if (_setters == null)
            {
                _setters = new ISetter[aliases.Length];
                for (var i = 0; i < aliases.Length; i++)
                {
                    var alias = aliases[i];
                    if (alias != null)
                    {
                        _setters[i] = _propertyAccessor.GetSetter(_resultClass, alias.Pascalize());
                    }
                }
            }

            result = _constructor.Invoke(null);

            for (var i = 0; i < _setters.Length; i++)
            {
                if (_setters[i] != null)
                {
                    _setters[i].Set(result, tuple[i]);
                }
            }
        }
        catch (InstantiationException e)
        {
            throw new HibernateException("Could not instantiate result class: " + _resultClass.FullName, e);
        }
        catch (MethodAccessException e)
        {
            throw new HibernateException("Could not instantiate result class: " + _resultClass.FullName, e);
        }

        return result;
    }

    public IList TransformList(IList collection)
    {
        return collection;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as AliasToClassResultTransformer);
    }

    public bool Equals(AliasToClassResultTransformer other)
    {
        if (ReferenceEquals(null, other))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return other._resultClass == _resultClass;
    }

    public override int GetHashCode()
    {
        return _resultClass.GetHashCode();
    }
}