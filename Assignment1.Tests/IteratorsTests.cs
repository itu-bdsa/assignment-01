namespace Assignment1.Tests;

public class IteratorsTests
{

    [Fact]
    public void flatten_should_return_a_stream_of_ints()
    {
        // Given
            IEnumerable<int> stream1 = new List<int>(){1, 2, 3};
            IEnumerable<int> stream2 = new List<int>(){2, 3, 4};
            IEnumerable<int> stream3 = new List<int>(){4, 5, 6};
            
            
        // When
            IEnumerable<IEnumerable<int>> bigStream = new List<IEnumerable<int>>(){stream1,stream2,stream3};
            IEnumerable<int> exptected = new List<int>(){1, 2, 3, 2, 3, 4, 4, 5, 6};

            var result = Iterators.Flatten(bigStream);

        // Then
            result.Should().BeEquivalentTo(new List<int>(){1, 2, 3, 2, 3, 4, 4, 5, 6});
    }

    [Fact]
    public void filter_should_return_a_stream_of_trueT()
    {
        // Given
            IEnumerable<int> stream = new List<int>(){1, 2, 3, 4, 5, 6};
            
            Predicate<int> even = Even;
            bool Even(int i) => i % 2 == 0;
                        
        // When
            var result = Iterators.Filter(stream, even);

        // Then
            result.Should().BeEquivalentTo(new List<int>(){2,4,6});
    }
}