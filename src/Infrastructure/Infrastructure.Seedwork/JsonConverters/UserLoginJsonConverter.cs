using System.Text.Json;
using System.Text.Json.Serialization;
using Infrastructure.Seedwork.DataTypes;

namespace Infrastructure.Seedwork.JsonConverters;

public class UserLoginJsonConverter: JsonConverter<UserLogin>
{
    public override UserLogin Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString()!;
        
        return (UserLogin)value;
    }

    public override void Write(Utf8JsonWriter writer, UserLogin value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Value);
    }
}