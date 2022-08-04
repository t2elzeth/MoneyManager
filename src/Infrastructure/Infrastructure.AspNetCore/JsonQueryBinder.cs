using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Infrastructure.DataTypes.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Logging;

namespace Infrastructure.AspNetCore;

public class JsonQueryBinder : IModelBinder
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions().ConfigureSystem();

    static JsonQueryBinder()
    {
        JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    }

    private readonly ILogger<JsonQueryBinder> _logger;
    private readonly IObjectModelValidator _validator;

    public JsonQueryBinder(ILogger<JsonQueryBinder> logger,
                           IObjectModelValidator validator)
    {
        _logger    = logger;
        _validator = validator;
    }

    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var value = bindingContext.ValueProvider.GetValue(bindingContext.FieldName).FirstValue;
        if (value == null)
            return Task.CompletedTask;

        try
        {
            var parsed = JsonSerializer.Deserialize(value,
                                                    bindingContext.ModelType,
                                                    JsonSerializerOptions);
            bindingContext.Result = ModelBindingResult.Success(parsed);

            if (parsed != null)
            {
                _validator.Validate(bindingContext.ActionContext,
                                    validationState: bindingContext.ValidationState,
                                    prefix: string.Empty,
                                    model: parsed);
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to bind '{FieldName}': {value}", bindingContext.FieldName, value);
            bindingContext.Result = ModelBindingResult.Failed();
        }

        return Task.CompletedTask;
    }
}