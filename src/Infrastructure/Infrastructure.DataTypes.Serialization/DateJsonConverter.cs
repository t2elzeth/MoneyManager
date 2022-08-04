using System.Text.Json;
using System.Text.Json.Serialization;

namespace Infrastructure.DataTypes.Serialization;

public class DateJsonConverter : JsonConverter<Date>
{
    public override Date Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString()!;
    }

    public override void Write(Utf8JsonWriter writer, Date value, JsonSerializerOptions options)
    {
        var stringDateTime = value.ToString();
        writer.WriteStringValue(stringDateTime);
    }
}