using Newtonsoft.Json;

namespace MoneyManager.Commons.Serializers;

public interface IStringSerializer
{
    T Deserialize<T>(string value);

    string Serialize<T>(T value);
}

public class StringSerializer : IStringSerializer
{
    public JsonSerializerSettings Settings { get; set; } = new()
    {
        Formatting           = Formatting.Indented,
        DefaultValueHandling = DefaultValueHandling.Ignore
    };

    public T Deserialize<T>(string value)
    {
        return JsonConvert.DeserializeObject<T>(value, Settings)!;
    }

    public string Serialize<T>(T value)
    {
        return JsonConvert.SerializeObject(value, Settings);
    }
}