using System.Security.Cryptography;
using System.Text;

namespace api.Utils; 

//常用工具类
public static class CommonUtil {
    public static string GetMd5Hash(string str) {
        using var md5Hash = MD5.Create();
        var byteData = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(str));
        var strBuilder = new StringBuilder();
        foreach (var b in byteData) {
            strBuilder.Append(b.ToString("x2"));
        }

        return strBuilder.ToString();
    }
}







