namespace Assignment1.Tests;

public class IteratorsTests
{
    [Fact]
    public void Flatten_given_arrays_return_one_array()
    {
        // Arrange
        List<List<int>> streams = new(){
            new(){1,2,3},
            new(){4,5,6},
            new(){7,8,9}
        };

        // Act

        // Assert
        IEnumerable<int> output = Iterators.Flatten<int>(streams);
        Assert.Equal(new int[]{1,2,3,4,5,6,7,8,9}, output);
        //output.Should().BeEquivalentTo(new int[]{1,2,3,4,5,6,7,8,9});
    }

    [Fact]
    public void Filter_given_1_to_10_returns_1_3_5_7_9()
    {
        // Arrange
        Predicate<int> odd = Odd;
        bool Odd(int i) => i % 2 != 0;

        int[] stream = {1,2,3,4,5,6,7,8,9,10};

        // Act 
        var output = Iterators.Filter<int>(stream, odd);

        //Assert
        Assert.Equal(new int[]{1,3,5,7,9}, output);
        //output.Should().Be(new int[]{1,3,5,7,9});
    }
}