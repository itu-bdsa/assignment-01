using Xunit; 
using FluentAssertions; 
namespace Assignment1.Tests;    


public class IteratorsTests
{
    [Fact]
    public void Should_Return_A_Stream_Of_Ts()
    {
        // Arrange
            var listOfLists = new List<List<int>>(); 
            listOfLists.Add(new List<int> {1, 2, 3, 4, 5});
            listOfLists.Add(new List<int> {6, 7, 8, 9, 10});
    
        // Act
            var result = Iterators.Flatten(listOfLists); 
    
        // Assert
            //result.Should().BeEquivalentTo(new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
            Assert.Equal(result, new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10});  

    }

    [Fact]
    
    public void Should_Return_True_On_Friday()
    {
        // Arrange
            var listOfLists = new List<WeekDays> { WeekDays.Monday, WeekDays.Tuesday, WeekDays.Wednesday, WeekDays.Wednesday, WeekDays.Friday};
            
            Predicate<WeekDays> predicate = Iterators.isFriday;  

        // Act 
            var result = Iterators.Filter(listOfLists, predicate);
        // Assert
            result.Should().BeEquivalentTo(new List<WeekDays> {WeekDays.Friday});

    }

    [Fact]
    
    public void Should_Return_Empty_Because_No_Friday(){
        // Arrange
        var listWithoutFriday = new List<WeekDays> { WeekDays.Monday, WeekDays.Tuesday, WeekDays.Wednesday, WeekDays.Wednesday};
        Predicate<WeekDays> predicate = Iterators.isFriday;  

        // Act 
        var resultShouldBeEmpty = Iterators.Filter(listWithoutFriday, predicate);
        // Assert
        resultShouldBeEmpty.Should().BeEmpty();

    }
}