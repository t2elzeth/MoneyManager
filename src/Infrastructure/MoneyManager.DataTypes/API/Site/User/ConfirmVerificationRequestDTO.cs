namespace MoneyManager.DataTypes.API.Site.User;

public class ConfirmVerificationRequestDTO
{
    public string Code { get; set; } = null!;

    public VerificationMethod Method { get; set; }

    public ImageDTO IdentityDocumentFrontImage { get; set; } = null!;

    public ImageDTO? IdentityDocumentBackImage { get; set; }
}