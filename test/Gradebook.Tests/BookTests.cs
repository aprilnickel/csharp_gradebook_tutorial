namespace Gradebook.Tests;

public class BookTests
{
    [Fact]
    public void BookCalculatesAverageGrade()
    {
        var book = new Book("Test Book");
        book.AddGrade(90.0);
        book.AddGrade(80.0);
        book.AddGrade(70.0);
        book.AddGrade(60.0);
        Statistics stats = book.GetStatistics();
        double actualAverage = stats.Average;
        
        Assert.Equal(75.0, actualAverage, 1);
    }
}
