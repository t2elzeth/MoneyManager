using Infrastructure.DataTypes;

namespace MoneyManager.DataTypes.API.Site.User;

public class UserIdentityDocumentDTO
{
    public long? Type { get; set; }

    public string Id { get; set; } = null!;

    public Date? IssueDate { get; set; }

    public Date? EndDate { get; set; }

    public string IssueOrganization { get; set; } = null!;

    public string? IssueOrganizationSubdivision { get; set; }

    public string VatNumber { get; set; } = null!;

    public ImageDTO? FrontImage { get; set; }

    public ImageDTO? BackImage { get; set; }

    public ImageDTO? FormImage { get; set; }
}