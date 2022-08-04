using System.Security.Cryptography;
using System.Text;

namespace MoneyManager.Commons.Extensions;

public static class CryptoExtensions
{
    public static string ComputeHash(this MD5 md5, string str, Encoding? encoding = null)
    {
        encoding ??= Encoding.ASCII;

        var bytes = encoding.GetBytes(str);

        var hash = md5.ComputeHash(bytes);

        var sBuilder = new StringBuilder();

        foreach (var b in hash)
        {
            sBuilder.Append(b.ToString("x2"));
        }

        return sBuilder.ToString();
    }
}