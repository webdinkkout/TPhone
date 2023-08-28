using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace CellPhoneS.Utils;

public class HandleSeoName
{
    public static string GenerateSEOName(string name)
    {
        string seoName = RemoveDiacritics(name).ToLower();
        seoName = Regex.Replace(seoName, @"\s+", "-");

        string prefix = Guid.NewGuid().ToString("N");
        seoName = $"{prefix}-{seoName}";
        return seoName;
    }

    private static string RemoveDiacritics(string text)
    {
        string formD = text.Normalize(NormalizationForm.FormD);
        StringBuilder sb = new StringBuilder();

        foreach (char ch in formD)
        {
            UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);
            if (uc != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(ch);
            }
        }

        return sb.ToString().Normalize(NormalizationForm.FormC);
    }
}