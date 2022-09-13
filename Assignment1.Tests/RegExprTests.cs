namespace Assignment1.Tests;

public class RegExprTests
{
    [Fact]
    public void Splitline()
    {
        // Arrange
        List<string> list = new List<string> {"Hello world", "Lorem Ipsum", "Hi there Bob", "Bob is 9 years old"};

        // Act
        var result = RegExpr.SplitLine(list);

        // Assert
        var expected = new List<string> {"Hello", "world", "Lorem", "Ipsum", "Hi", "there", "Bob", "Bob", "is", "9", "years", "old"};
        result.Should().BeEquivalentTo(expected);
    }
}