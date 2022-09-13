namespace Assignment1;
using System.Text.RegularExpressions;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            foreach (var word in Regex.Split(line, @"[^a-zA-Z0-9]+"))
            {
                if (word != "")
                {
                    yield return word;
                }
            }
        }

    }

    public static IEnumerable<(int width, int height)> Resolution(string resolutions) => throw new NotImplementedException();

    public static IEnumerable<string> InnerText(string html, string tag) => throw new NotImplementedException();
}