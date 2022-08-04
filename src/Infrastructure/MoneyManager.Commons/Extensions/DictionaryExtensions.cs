using System;
using System.Collections.Generic;

namespace MoneyManager.Commons.Extensions;

public static class DictionaryExtensions
{
    public static bool TryGetValue<TType>(this IDictionary<string, object>? dictionary, string path, out TType result)
    {
        object? current = dictionary;

        foreach (var key in path.Split('.'))
        {
            if (current is IDictionary<string, object> dict)
            {
                if (!dict.TryGetValue(key, out current))
                {
                    result = default;
                    return false;
                }
            }
            else
            {
                result = default;
                return false;
            }
        }

        if (current is TType type)
        {
            result = type;
            return true;
        }

        if (current is IConvertible)
        {
            result = (TType)Convert.ChangeType(current, typeof(TType));
            return true;
        }

        result = default;
        return false;
    }
}