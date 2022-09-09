namespace Assignment1;
using System.Text.RegularExpressions;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines) {
        // var pattern = @"^\w[a-z]+ \w[a-z]+";
        // var pattern = @"^\w[a-z]+ *";
        var pattern = @"^(?<word>\w[a-z]+[ +])*" ;

        foreach (var s in lines)
        {
            var match = Regex.Match(s,pattern);
            if(match.Success){
                yield return s;
            }         
        }
    }
}

//     public static IEnumerable<(int width, int height)> Resolution(string resolutions) {


//     }

//     public static IEnumerable<string> InnerText(string html, string tag) {

//     }
// }
