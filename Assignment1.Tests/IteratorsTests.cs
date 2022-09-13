namespace Assignment1.Tests;

public class IteratorsTests
{
        [Fact]
        public void Flatten_1_2_break_4_5_break_2_6_gives_1_2_4_5_2_6()
        {
            //Arrange
            var l1 = new List<int> {1, 2};
            var l2 = new List<int> {4, 5};
            var l3 = new List<int> {2, 6};
            var inputList = new List<List<int>> {l1, l2, l3};
            var answer = new List<int> {1, 2, 4, 5, 2, 6};

            //Act
            var output = Iterators.Flatten<int>(inputList);

            //Assert
            Assert.Equal(answer, output);
        }

                [Fact]
        public void Filter_1_2_3_4_5_For_Evens_Gives_2_4()
        {
            //Arrange
            var list = new List<int> {1, 2, 3, 4, 5};
            Predicate<int> even = Even;
            bool Even(int i) => i % 2 == 0;
            var answer = new List<int> {2, 4};

            //Act
            var output = Iterators.Filter(list, even);

            //Assert
            Assert.Equal(answer, output);
        }
}