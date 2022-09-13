namespace Assignment1;
using System.Text.RegularExpressions;  

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
    {
        foreach (string s in lines)
        {
            foreach (string d in Regex.Split(s, " "))
            {
                yield return d;
            }
        }
    }

   public static IEnumerable<(int width, int height)> Resolution(string resolutions) {
        string pattern = @"(?<reso_one>\d{3,4})x(?<reso_two>\d{3,4})";
        Regex regex = new Regex(pattern);
        foreach (Match match in regex.Matches(resolutions)) {
            yield return (Int32.Parse(match.Groups[1].Value), Int32.Parse(match.Groups[2].Value));
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag) => throw new NotImplementedException();
}