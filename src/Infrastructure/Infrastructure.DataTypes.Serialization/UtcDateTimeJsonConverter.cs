using System.Text.Json;
using System.Text.Json.Serialization;

namespace Infrastructure.DataTypes.Serialization;

public class UtcDateTimeJsonConverter : JsonConverter<UtcDateTime>
{
    public override UtcDateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString()!;
    }

    public override void Write(Utf8JsonWriter writer, UtcDateTime value, JsonSerializerOptions options)
    {
        var stringDateTime = (string) value;
        writer.WriteStringValue(stringDateTime);
    }
}