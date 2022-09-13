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


}