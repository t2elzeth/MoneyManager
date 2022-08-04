using JetBrains.Annotations;

namespace MoneyManager.DataTypes.API.Internal.Country;

[UsedImplicitly]
public class UpdateMonitoredCountryRequest
{
    [UsedImplicitly]
    public long Id { get; set; }

    [UsedImplicitly]
    public bool IsMonitored { get; set; }
}