namespace Assignment1.Tests;
using Xunit;
using FluentAssertions;

public class IteratorsTests
{

    [Fact]
    public void flatten_should_return_single_stream_of_t()
    {
        //Arrange
        var innerlist1 = new List<int>() { 1, 2, 3, 4, 5 };
        var innerlist2 = new List<int>() { 1, 2, 3, 4, 5 };
        var list1 = new List<IEnumerable<int>>() { innerlist1, innerlist2 };


        //Act
        var actual = Iterators.Flatten(list1);
        //Assert
        actual.Should().BeEquivalentTo(new List<int>() { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 });
    }

    [Fact]
    public void filter_should_return_2_and_4_given_12345_with_even_predicate() {
        // Arrange
        var list = new List<int>() { 1, 2, 3, 4, 5 };
        Predicate<int> even = Even;
        bool Even(int i) => i % 2 == 0;

        // Act
        var actual = Iterators.Filter<int>(list, even);

        // Assert
        Assert.Equal(new List<int> { 2, 4 }, actual);
    }
    
}