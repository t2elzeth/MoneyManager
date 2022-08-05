using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Infrastructure.Seedwork.JsonConverters;

namespace Infrastructure.Seedwork.Extensions;

public static class SystemSerializerExtensions
{
    public static JsonSerializerOptions AddConverter(this JsonSerializerOptions options,
                                                     JsonConverter converter)
    {
        options.Converters.Add(converter);

        return options;
    }

    public static JsonSerializerOptions ConfigureSystemConventions(this JsonSerializerOptions options)
    {
        options.Encoder                     = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
        options.WriteIndented               = false;
        options.PropertyNameCaseInsensitive = true;
        options.PropertyNamingPolicy        = JsonNamingPolicy.CamelCase;
        options.DictionaryKeyPolicy         = JsonNamingPolicy.CamelCase;
        options.DefaultIgnoreCondition      = JsonIgnoreCondition.WhenWritingNull;

        return options;
    }

    public static JsonSerializerOptions ConfigureSystemConverters(this JsonSerializerOptions options)
    {
        options.Converters.Add(new TimeSpanJsonConverter());
        options.Converters.Add(new DictionaryJsonConverter());
        options.Converters.Add(new ImmutableDictionaryJsonConverter());
        options.Converters.Add(new ObjectJsonConverter());
        options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        options.Converters.Add(new ObjectJsonConverter());
        options.Converters.Add(new UtcDateTimeJsonConverter());
        options.Converters.Add(new DateJsonConverter());

        return options;
    }

    public static JsonSerializerOptions ConfigureSystem(this JsonSerializerOptions options)
    {
        options.ConfigureSystemConventions()
               .ConfigureSystemConverters();

        return options;
    }
}