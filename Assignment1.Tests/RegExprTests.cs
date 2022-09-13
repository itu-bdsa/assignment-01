namespace Assignment1.Tests;

public class RegExprTests
{

    [Fact]
    public void splitLine_should_return_stream_of_words()
    {
        // Given
            IEnumerable<string> stream = new List<string>(){"eyo man", "lol brah ur", "901 80"};
            
        // When
            var result = RegExpr.SplitLine(stream);

        // Then
            result.Should().BeEquivalentTo(new List<string>(){"eyo", "man", "lol", "brah", "ur", "901", "80"});
    }

    [Fact]
    public void Resolution_should_return_stream_tuples()
    {
        // Given
            var string1 = "1024x768, 800x600, 640x480";
            var string2 = "320x200, 320x240, 800x600";
            
        // When
            var result1 = RegExpr.Resolution(string1);
            var result2 = RegExpr.Resolution(string2);

        // Then
            result1.Should().BeEquivalentTo(new List<(int width, int height)>(){(1024, 768), (800, 600), (640, 480)});
            result2.Should().BeEquivalentTo(new List<(int width, int height)>(){(320, 200), (320, 240), (800, 600)});
    }

    [Fact]
    public void InnerText_should_return_innertext_of_tag()
    {
        // Given
            var html = "<div> <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p></div>";
            
        // When
            var result = RegExpr.InnerText(html, "a");

        // Then
            result.Should().BeEquivalentTo(new List<string>(){"theoretical computer science","formal language", "characters", "pattern", "string searching algorithms", "strings"});
    }
}