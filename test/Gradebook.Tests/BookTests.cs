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
        
        Assert.Equal(75.0, stats.Average, 1);
        Assert.Equal(90.0, stats.High, 1);
        Assert.Equal(60.0, stats.Low, 1);
        Assert.Equal('C', stats.Letter);
    }
    
    [Fact]
    public void GradeMustBeBetween0And100()
    {
        var book = new Book("Test Book");
        book.AddGrade(-12);
        book.AddGrade(105);
        Statistics stats = book.GetStatistics();
        
        Assert.Equal(0.0, stats.Average);
        Assert.Equal(double.MinValue, stats.High);
        Assert.Equal(double.MaxValue, stats.Low);
    }
}
