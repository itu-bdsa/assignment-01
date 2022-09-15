namespace Assignment1;

using System.Text.RegularExpressions;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines){

        var pattern = @"(?<word>\w[a-z]*[0-9]*)+";

        foreach(var l in lines){ 
            var match = Regex.Match(l, pattern);
            while(match.Success){
                yield return match.Groups["word"].Value;
                match = match.NextMatch();
            }
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(string resolutions){

        var pattern = @"(?<width>[0-9]+)x(?<height>[0-9]+)([, ] )*";

        var match = Regex.Match(resolutions, pattern);
        while(match.Success){
            yield return (int.Parse(match.Groups["width"].Value), int.Parse(match.Groups["height"].Value));
            match = match.NextMatch();
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag){

        //var pattern = @"<([a]?)[^>]*>(?<innerText>.*?)</\1>";
        var pattern = $@"<([{tag}]?)[^>]*>(?<innerText>.*?)</\1>";

        var match = Regex.Match(html, pattern);
        while(match.Success){
                //yield return Regex.Replace(match.Groups["innerText"].Value, $@"</?[a-z]*>", "");
                yield return Regex.Replace(match.Groups["innerText"].Value, $@"</?.*?>", "");
                match = match.NextMatch();
            }
        //OBS - tjek test for nested tag p i orig text
    }

    public static IEnumerable<(Uri url, string title)> Urls(string html){
        var pattern = $@"<([a-z]+) href=""(?<url>.*?)?""( [title=""]+(?<titleText>[(]*[A-Za-z ]+[)]*)"")*[^>]*>(?<innerText>.*?)</\1>";

        var match = Regex.Match(html, pattern);
        
        while(match.Success){
            Uri l = new Uri(match.Groups["url"].Value);
            if(match.Groups["titleText"].Value != ""){
                yield return (l, match.Groups["titleText"].Value);
            } else {
                yield return (l, match.Groups["innerText"].Value);
            }
            match = match.NextMatch();
        }
    }
}