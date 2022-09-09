namespace Assignment1.Tests;

public class RegExprTests
{

    [Fact]
    public void shoud_return_hej_med_dig(){

        //Act
        IEnumerable<string> stream = new List<string>(){"hej med dig ", "har du det godt"};
         
         //Arrange
        var result = RegExpr.SplitLine(stream);
        Console.WriteLine(result);

         //Assert
         result.Should().BeEquivalentTo(new List<string>(){"hej","med","dig"});
    }
}