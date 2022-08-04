using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace MoneyManager.Commons;

public static class XmlUtils
{
    private static string GetValueAsString(this XObject xObject)
    {
        if (xObject is XElement xElement)
            return xElement.Value;

        if (xObject is XAttribute xAttribute)
            return xAttribute.Value;

        if (xObject is XText xText)
            return xText.Value;

        throw new Exception($"Cannot get string value from '{xObject}'");
    }

    public static bool GetValueAsBoolean(this XObject xObject)
    {
        var value = xObject.GetValueAsString();

        switch (value)
        {
            case "1":
                return true;

            case "0":
                return false;
        }

        return bool.Parse(value);
    }

    public static byte GetValueAsByte(this XObject xObject)
    {
        var value = xObject.GetValueAsString();

        return byte.Parse(value);
    }

    public static short GetValueAsShort(this XObject xObject)
    {
        var value = xObject.GetValueAsString();

        return short.Parse(value);
    }

    public static int GetValueAsInt(this XObject xObject)
    {
        var value = xObject.GetValueAsString();

        return int.Parse(value);
    }

    public static long GetValueAsLong(this XObject xObject)
    {
        var value = xObject.GetValueAsString();

        return long.Parse(value);
    }
    public static decimal GetValueAsDecimal(this XObject xObject)
    {
        var value = xObject.GetValueAsString();

        return decimal.Parse(value);
    }

    public static Type GetValueAsType(this XObject xObject)
    {
        var value = xObject.GetValueAsString();

        return Type.GetType(value, true);
    }

    public static Guid GetValueAsGuid(this XObject xObject)
    {
        var value = xObject.GetValueAsString();

        return Guid.Parse(value);
    }

    public static T GetValueAsEnum<T>(this XObject xObject)
    {
        var value = xObject.GetValueAsString();

        return (T)Enum.Parse(typeof(T), value);
    }

    public static bool TryGetElement(this XElement xElement, XName name, out XElement element)
    {
        element = xElement.Element(name);

        return element != null;
    }

    public static bool TryGetElements(this XElement xElement, XName name, out IList<XElement> elements)
    {
        var res = xElement.Elements(name);

        elements = res as IList<XElement> ?? res.ToArray();

        return elements.Count > 0;
    }

    public static bool TryGetAttribute(this XElement xElement, XName name, out XAttribute attribute)
    {
        attribute = xElement.Attribute(name);

        return attribute != null;
    }

    public static XElement SubElement(this XElement xElement)
    {
        return xElement.Elements().FirstOrDefault();
    }
}