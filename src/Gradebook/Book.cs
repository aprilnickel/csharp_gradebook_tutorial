namespace Gradebook;

public delegate void GradeAddedDelegate(object sender, BookGradeAddedEventArgs args);

public abstract class Book : NamedObject, IBook
{
    public Book() : base()
    {
    }
    
    public Book(string name) : base(name)
    {
    }
    
    public abstract event GradeAddedDelegate GradeAdded;
    public abstract void AddGrade(double grade);
    public abstract Statistics GetStatistics();

    public void DisplayStatistics()
    {
        Statistics stats = GetStatistics();

        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Highest grade: {stats.High}");
        Console.WriteLine($"Lowest grade: {stats.Low}");
        Console.WriteLine($"Average grade: {stats.Average}");
        Console.WriteLine($"Letter grade: {stats.Letter}");
    }

    public abstract void DisplayGrades();
}
