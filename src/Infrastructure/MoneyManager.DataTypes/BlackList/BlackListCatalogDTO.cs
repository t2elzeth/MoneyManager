using System;
using JetBrains.Annotations;

namespace MoneyManager.DataTypes.BlackList;

[UsedImplicitly]
public class BlackListCatalogDTO
{
    [UsedImplicitly]
    public long Id { get; set; }

    [UsedImplicitly]
    public string Name { get; set; } = null!;

    [UsedImplicitly]
    public DateTime LastUpdate { get; set; }
}