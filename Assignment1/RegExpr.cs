namespace Assignment1;

using System.Text.RegularExpressions;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines){

        var pattern = @"(?<word>\w[a-z]*[0-9]*)+";

        foreach(var l in lines){
            //var match = Regex.Match(l, pattern);
            var match = Regex.Matches(l, pattern);
            //split og spyt ud
            //if(match.Success){
            foreach(Match m in match){
                yield return m.Groups["word"].Value;
                //yield return m.ToString();
            }
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(string resolutions){

        var pattern = @"(?<width>[0-9]+)x(?<height>[0-9]+)([, ] )*";

        var match = Regex.Matches(resolutions, pattern);
        //OBS - er match en collection? Tjek om man kan lave noget med et
        //for-loop i stedet. Samme i andre opgaver med .Matches!

        foreach(Match m in match){
            yield return (int.Parse(m.Groups["width"].Value), int.Parse(m.Groups["height"].Value));
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag){

        //var pattern = @"<([a]?)[^>]*>(?<innerText>.*?)</\1>";
        var pattern = $@"<([{tag}]?)[^>]*>(?<innerText>.*?)</\1>";

        var match = Regex.Matches(html, pattern);

        foreach(Match m in match){
            yield return m.Groups["innerText"].Value;
        }

    }

    public static IEnumerable<(Uri url, string title)> Urls(string html){
        //Urls takes as argument a string containing HTML and returns all urls with
        // their titles if any, otherwise innerText.
        var pattern = $@"<([a-z]?) href=""(?<url>.*?)?"" [title=""]+(?<titleText>([(]*[A-Za-z ]+[)]*)+)[^>]*>(?<innerText>.*?)</\1>";

        var match = Regex.Matches(html, pattern);
        
        foreach(Match m in match){
            Uri l = new Uri(m.Groups["url"].Value);
            if(m.Groups["titleText"].Value != null){
                yield return (l, m.Groups["titleText"].Value);
            } else {
                yield return (l, m.Groups["innerText"].Value);
            }
            
        }
    }
}