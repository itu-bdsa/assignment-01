namespace Assignment1;

using System.Text.RegularExpressions;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
    {
        var pattern = @"[(a-z)(A-Z)0-9]+";
        foreach(string line in lines)
        {
            foreach(Match match in Regex.Matches(line, pattern))
            {
                yield return match.Value;
            }
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions)
    {
        var pattern = @"(?'res'[0-9]+)(?:x)(?'res2'[0-9]+)";
        foreach(string resolution in resolutions)
        {
            foreach(Match match in Regex.Matches(resolution, pattern))
            {
                int width, height;
                Int32.TryParse(match.Groups["res"].Value, out width);
                Int32.TryParse(match.Groups["res2"].Value, out height);
                yield return (width, height);
            }
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag)
    {
        //var pattern = @"(?<=<([" + tag + @"]+).*?>)(?'innertext'[\p{L} </().,]+)(?=</\1>)";
        var pattern = @"(?<=<([" + tag + "]+)[\\p{L} ()=\":/_.]*?>)(?'innertext'.+?)(?=</\\1>)";
        foreach(Match match in Regex.Matches(html, pattern))
        {
            string innerText = match.Groups["innertext"].Value;
            yield return Regex.Replace(innerText, @"<.*?>", "");
        }
    }

    public static IEnumerable<(Uri url, string title)> Urls(string html)
    {
        var patternInsideTag = @"<([a])(?'inn'.*?)>(.*?)</\1>";
        foreach(Match match in Regex.Matches(html, patternInsideTag))
        {
            string inn = match.Groups["inn"].Value;
            
            if(inn.Contains("title"))
            {
                var patternUrl = @"https?://[\p{L}.-/_()]+";
                var patternTitle = @"(?<=title=.).*(?=.)";
                string url = Regex.Match(inn, patternUrl).Value;
                string title = Regex.Match(inn, patternTitle).Value;
                yield return (new Uri(url), title);
            }
            else
            {
                var patternUrl = @"https?://[\p{L}.-/_()]+";
                string url = Regex.Match(inn, patternUrl).Value;
                yield return (new Uri(url),InnerText(match.Value, "a").First());
            }
        }
    }
}