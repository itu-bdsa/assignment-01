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

    public static IEnumerable<(int width, int height)> Resolution(string resolutions) => throw new NotImplementedException();

    public static IEnumerable<string> InnerText(string html, string tag) => throw new NotImplementedException();
}