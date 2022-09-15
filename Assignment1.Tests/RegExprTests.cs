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
    public void InnerText_should_return_innertext_of_tag_a()
    {
        // Given
            var html = "<div> <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p></div>";
            
        // When
            var result = RegExpr.InnerText(html, "a");

        // Then
            result.Should().BeEquivalentTo(new List<string>(){"theoretical computer science","formal language", "characters", "pattern", "string searching algorithms", "strings"});

    }

    [Fact]
    public void InnerText_should_return_all_text_from_nested_tag_p()
    {
        // Given
            var html = "<div> <p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p> </div>";
            
        // When
            var result = RegExpr.InnerText(html, "p");

        // Then
            result.Should().BeEquivalentTo(new List<string>(){"The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to."});

    }

    [Fact]
    public void InnerText_should_return_all_text_from_nested_tag_p_in_longText()
    {
        // Given
            var html = "<div> <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p></div>";
            
        // When
            var result = RegExpr.InnerText(html, "p");

        // Then
            result.Should().BeEquivalentTo(new List<string>(){"A regular expression, regex or regexp (sometimes called a rational expression) is, in theoretical computer science and formal language theory, a sequence of characters that define a search pattern. Usually this pattern is then used by string searching algorithms for \"find\" or \"find and replace\" operations on strings."});

    }

    [Fact]
    public void Urls_should_return_url_and_titleOfUrl()
    {
        // Given
            var html = "<div> <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p></div>";
            
        // When
            var result = RegExpr.Urls(html);

        // Then
            result.Should().BeEquivalentTo(new List<(Uri url, string title)>()
            {(new Uri("https://en.wikipedia.org/wiki/Theoretical_computer_science"), "Theoretical computer science"),
             (new Uri("https://en.wikipedia.org/wiki/Formal_language"), "Formal language"),
             (new Uri("https://en.wikipedia.org/wiki/Character_(computing)"), "Character (computing)"), 
             (new Uri("https://en.wikipedia.org/wiki/Pattern_matching"), "Pattern matching"),
             (new Uri("https://en.wikipedia.org/wiki/String_searching_algorithm"), "String searching algorithm"), 
             (new Uri("https://en.wikipedia.org/wiki/String_(computer_science)"), "String (computer science)")});

    }

    [Fact]
    public void Urls_should_return_url_and_innerText()
    {
        // Given
            var html = "<div> <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\">innertext heeere</a>";
            
        // When
            var result = RegExpr.Urls(html);

        // Then
            result.Should().BeEquivalentTo(new List<(Uri url, string title)>()
            {(new Uri("https://en.wikipedia.org/wiki/Theoretical_computer_science"), "Theoretical computer science"),
             (new Uri("https://en.wikipedia.org/wiki/Formal_language"), "innertext heeere")});

    }
}