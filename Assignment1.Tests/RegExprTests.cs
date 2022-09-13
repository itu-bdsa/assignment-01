namespace Assignment1.Tests;
using FluentAssertions;
using Xunit;

public class RegExprTests
{
    
    [Fact]
    public void split_line_should_return_stream_of_words()
    {
        //Arrange
        var line1 = "hello there";
        var line2 = "these are words";
        var list1 = new List<string>() { line1, line2 };
        
        // Act
        var actual = RegExpr.SplitLine(list1);
        
        
        // Assert
        actual.Should().BeEquivalentTo(new List<string>() {"hello", "there", "these", "are", "words"});

    }

    
    [Fact]
    public void Resolution_Sample_Input_Gives_Correct_OutPut() {
        // Arrange
        var sampleInput = "1024x768, 800x600, 640x480";

        // Act
        var actual = RegExpr.Resolution(sampleInput);

        // Assert
        var expected = new List<Tuple<int, int>>();
        expected.Should().BeEquivalentTo(actual);
    }
}