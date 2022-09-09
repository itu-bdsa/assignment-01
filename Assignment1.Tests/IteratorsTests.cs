namespace Assignment1.Tests;

public class IteratorsTests
{
    [Fact]
    public void flatten() 
    {
        // Arrange
        List<List<int>> listInList = new List<List<int>>();
        listInList.Add(new List<int>{1,2,3});
        listInList.Add(new List<int>{4,5,6});
        listInList.Add(new List<int>{7,8,9});

        // Act 
        var result = Iterators.Flatten<int>(listInList);

        // Assert
        result.Should().BeEquivalentTo(new List<int> {1,2,3,4,5,6,7,8,9});
    }
    
}