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

        Assert.Equal(count, 5);

    }

}