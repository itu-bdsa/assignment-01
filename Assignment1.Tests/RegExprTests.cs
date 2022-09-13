namespace Assignment1.Tests;
using FluentAssertions;
using Xunit;

public class RegExprTests
{
    [Fact]
    public void SplitLine_Empty()
    {
        // Arrange
        var empty = Enumerable.Empty<string>();

        // Act
        var actual = Assignment1.RegExpr.SplitLine(empty);

        // Assert
        actual.Should().BeEmpty();
    }

    [Fact]
    public void SplitLine_Single()
    {
        // Arrange
        var single = new[] { "Hello, World!" };

        // Act
        var actual = Assignment1.RegExpr.SplitLine(single);

        // Assert
        actual.Should().Equal("Hello", "World");
    }

    [Fact]
    public void SplitLine_Multiple()
    {
        // Arrange
        var multiple = new[] { "Hello, World!", "Hello, Test!" };

        // Act
        var actual = Assignment1.RegExpr.SplitLine(multiple);

        // Assert
        actual.Should().Equal("Hello", "World", "Hello", "Test");
    }
}