using System.Text.Json;
using System.Text.Json.Serialization;

namespace Infrastructure.DataTypes.Serialization;

public class KgDateTimeJsonConverter : JsonConverter<KgDateTime>
{
    public override KgDateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString()!;
    }

    public override void Write(Utf8JsonWriter writer, KgDateTime value, JsonSerializerOptions options)
    {
        var stringDateTime = (string)value;
        writer.WriteStringValue(stringDateTime);
    }
}