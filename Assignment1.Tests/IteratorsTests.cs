namespace Assignment1.Tests;

public class IteratorsTests
{
    [Fact]
    public void FilterAllTrueNaturalNumbers(){
        //Setup
        Predicate<int> all = All;
        bool All(int i) => true;
        var input = new List<int>();
        for(int i = 0; i < 5; i++){
            input.Add(i);
        }

        //Act
        var output = Iterators.Filter<int>(input, all);

        //Assert
        var count = 0;
        foreach(int value in output){
            count++;
        }

        Assert.Equal(5, count);
    }

    [Fact]
    public void FilterAllTrueNaturalNumbersStartingHigh(){
        //Setup
        Predicate<int> all = All;
        bool All(int i) => true;
        var input = new List<int>();
        for(int i = 100; i < 105; i++){
            input.Add(i);
        }

        //Act
        var output = Iterators.Filter<int>(input, all);

        //Assert
        var count = 0;
        foreach(int value in output){
            count++;
        }
        Assert.Equal(5, count);
    }

    [Fact]
    public void FilterEvensOnly(){
        //Setup
        Predicate<int> even = Even;
        bool Even(int i) => i % 2 == 0;
        var input = new List<int>();
        for(int i = 0; i < 10; i++){
            input.Add(i);
        }

        //Act
        var output = Iterators.Filter<int>(input, even);

        //Assert
        var count = 0;
        foreach(int value in output){
            count++;
        }
        Assert.NotEqual(output, input);
        Assert.Equal(5, count);
    }

    [Fact]
    public void FilterEmpty(){
        //Setup
        Predicate<int> even = Even;
        bool Even(int i) => i % 2 == 0;
        var input = new List<int>();

        //Act
        var output = Iterators.Filter<int>(input, even);

        //Assert
        var count = 0;
        foreach(int value in output){
            count++;
        }
        Assert.Equal(0, count);
    }

    [Fact]
    public void FlattenThreeNestedLists(){
        //Setup

        List<List<int>> input = new List<List<int>>()
        {
            new List<int>() { 1, 2, 3 },
            new List<int>() { 4, 5 },
            new List<int>() { 6, 7, 8, 9 }
        };

        //Act
        var output = Iterators.Flatten<int>(input);

        //Assert
        var expectedValue = 1;
        foreach (var item in output)
        {
            Assert.Equal(expectedValue, item);
            expectedValue++;
        }
    }

        [Fact]
    public void FlattenEmpty(){
        //Setup
        List<List<int>> input = new List<List<int>>();
        //Act
        var output = Iterators.Flatten<int>(input);

        //Assert
        foreach (var item in output)
        {
            Assert.True(false);
        }
    }

}