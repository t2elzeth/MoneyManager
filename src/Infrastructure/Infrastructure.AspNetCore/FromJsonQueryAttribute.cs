using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.AspNetCore;

public class FromJsonQueryAttribute : ModelBinderAttribute
{
    public FromJsonQueryAttribute()
    {
        BinderType = typeof(JsonQueryBinder);
    }
}