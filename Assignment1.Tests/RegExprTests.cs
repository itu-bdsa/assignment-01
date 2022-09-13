namespace Assignment1.Tests;

public class RegExprTests
{
    [Fact]
    public void SplitLine_given_something_returns_something()
    {
        // Arrange
        string[] stream = {
            "this is my line1",
            "dette er min linje2",
            "das ist meine Zeile3"
        };

        // Act

        // Assert
        var output = RegExpr.SplitLine(stream);
        var expected = new string[]{
            "this", "is", "my", "line1",
            "dette", "er", "min", "linje2",
            "das", "ist", "meine", "Zeile3"
        };
        Assert.Equal(expected, output);
    }

    [Fact]
    public void Resolutions_given_sample_input()
    {
        // Arrange
        string[] stream = {
            "1920x1080",
            "1024x768, 800x600, 640x480",
            "320x200, 320x240, 800x600",
            "1280x960"
        };

        // Act

        // Assert
        var output = RegExpr.Resolution(stream);
        var expected = new[] {
            (1920, 1080),
            (1024, 768),
            (800, 600),
            (640, 480),
            (320, 200),
            (320, 240),
            (800, 600),
            (1280, 960),
        };
        Assert.Equal(expected, output);
    }

    [Fact]
    public void InnerText_given_sample_input()
    {
        // Arrange
        string input = "<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p></div>";

        // Act
        var output = RegExpr.InnerText(input, "a");

        //Assert
        string[] expected = {
            "theoretical computer science",
            "formal language",
            "characters",
            "pattern",
            "string searching algorithms",
            "strings"
        };

        Assert.Equal(expected, output);
    }

    [Fact]
    public void InnerText_given_sample_input_paragraph()
    {
        // Arrange
        string html = "<div><p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p></div>";

        //Act
        var output = RegExpr.InnerText(html, "p");
        
        //Assert
        var expected = new string[] {
            "The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to."
        };
        Assert.Equal(expected, output);
    }

    [Fact]
    public void Urls_given_sample_input()
    {
        // Arrange
        string input = "<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p></div>";

        // Act
        var output = RegExpr.Urls(input);

        //Assert
        (Uri, string)[] expected = {
            (new Uri("https://en.wikipedia.org/wiki/Theoretical_computer_science"), "Theoretical computer science"),
            (new Uri("https://en.wikipedia.org/wiki/Formal_language"),"Formal language"),
            (new Uri("https://en.wikipedia.org/wiki/Character_(computing)"), "Character (computing)"),
            (new Uri("https://en.wikipedia.org/wiki/Pattern_matching"), "Pattern matching"),
            (new Uri("https://en.wikipedia.org/wiki/String_searching_algorithm"), "String searching algorithm"),
            (new Uri("https://en.wikipedia.org/wiki/String_(computer_science)"), "String (computer science)")
        };

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Urls_given_sample_input_without_title()
    {
        // Arrange
        string input = "<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p></div>";

        // Act
        var output = RegExpr.Urls(input);

        //Assert
        (Uri, string)[] expected = {
            (new Uri("https://en.wikipedia.org/wiki/Theoretical_computer_science"), "theoretical computer science"),
            (new Uri("https://en.wikipedia.org/wiki/Formal_language"),"Formal language"),
            (new Uri("https://en.wikipedia.org/wiki/Character_(computing)"), "Character (computing)"),
            (new Uri("https://en.wikipedia.org/wiki/Pattern_matching"), "Pattern matching"),
            (new Uri("https://en.wikipedia.org/wiki/String_searching_algorithm"), "String searching algorithm"),
            (new Uri("https://en.wikipedia.org/wiki/String_(computer_science)"), "String (computer science)")
        };

        Assert.Equal(expected, output);
    }
}