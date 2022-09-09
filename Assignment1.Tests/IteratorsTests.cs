namespace Assignment1.Tests;

public class IteratorsTests
{

    [Fact]
    public void flatten_should_return_a_stream_of_ints()
    {
        // Act 
            IEnumerable<int> stream1 = new List<int>(){1, 2, 3};
            IEnumerable<int> stream2 = new List<int>(){2, 3, 4};
            IEnumerable<int> stream3 = new List<int>(){4, 5, 6};
            
        // Arrange
            IEnumerable<IEnumerable<int>> bigStream = new List<IEnumerable<int>>(){stream1,stream2,stream3};
            var result = Iterators.Flatten(bigStream);

        // Assert
            result.Should().BeEquivalentTo(new List<int>(){1, 2, 3, 2, 3, 4, 4, 5, 6});
    }

    [Fact]
    public void filter_should_return_a_stream_of_trueT()
    {
        // Act
            IEnumerable<int> stream = new List<int>(){1, 2, 3, 4, 5, 6};

            Predicate<int> even = Even;
            bool Even(int i) => i % 2 == 0;
                        
        // Arrange
            var result = Iterators.Filter(stream, even);

        // Assert
            result.Should().BeEquivalentTo(new List<int>(){2,4,6});
    }
}