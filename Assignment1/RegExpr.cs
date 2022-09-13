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
        string pattern = @"^([1-5][0-9]{2}|600)x";
        Regex regex = new Regex(pattern);
        foreach (Match match in regex.Matches(resolutions)) {
            var previous = 0;
            if(previous != 0) {
                yield return (previous, Int32.Parse(match.Value));
            }
            previous = Int32.Parse(match.Value);
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag) => throw new NotImplementedException();
}