using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MoneyManager.Commons.Serializers;

public class ObjectConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(object);
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        writer.WriteStartObject();
        writer.WriteEndObject();
    }

    public override object? ReadJson(JsonReader reader,
                                     Type objectType,
                                     object? existingValue,
                                     JsonSerializer serializer)
    {
        object? value = null;
        switch (reader.TokenType)
        {
            case JsonToken.Null:
                return null;

            case JsonToken.StartObject:
                value = new Dictionary<string, object>();
                break;

            case JsonToken.StartArray:
                value = new List<object>();
                break;
        }

        if (value != null)
        {
            serializer.Populate(reader, value);
            return value;
        }

        return serializer.Deserialize(reader);
    }
}