using System.Text.Json;
using System.Text.Json.Serialization;

namespace Infrastructure.DataTypes.Serialization;

public class GmtDateTimeJsonConverter : JsonConverter<GmtDateTime>
{
    public override GmtDateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString()!;
    }

    public override void Write(Utf8JsonWriter writer, GmtDateTime value, JsonSerializerOptions options)
    {
        throw new NotSupportedException();
    }
}