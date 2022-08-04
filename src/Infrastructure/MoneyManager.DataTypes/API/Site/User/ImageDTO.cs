namespace MoneyManager.DataTypes.API.Site.User;

public class ImageDTO
{
    public string MimeType { get; set; } = null!;

    public byte[] Content { get; set; } = null!;
}