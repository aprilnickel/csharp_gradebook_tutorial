namespace Gradebook;

class Program
{
    static void Main(string[] args)
    {
        var book = new Book("Grade Book");
        book.AddGrade(55);
        book.AddGrade(99);
        book.AddGrade(88);
        book.AddGrade(92);
        book.AddGrade(65);
        Statistics stats = book.GetStatistics();
        
        Console.WriteLine($"Highest grade: {stats.High}");
        Console.WriteLine($"Lowest grade: {stats.Low}");
        Console.WriteLine($"Average grade: {stats.Average}");
    }
}
