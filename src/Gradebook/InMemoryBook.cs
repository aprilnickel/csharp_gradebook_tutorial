namespace Gradebook;

public interface IBook
{
    void AddGrade(double grade);
    Statistics GetStatistics();
    void DisplayStatistics();
    void DisplayGrades();
    string Name { get; }
    event GradeAddedDelegate GradeAdded;
}

public abstract class Book : NamedObject, IBook
{
    public Book() : base()
    {
    }
    
    public Book(string name) : base(name)
    {
    }
    
    public virtual event GradeAddedDelegate GradeAdded;
    
    public abstract void AddGrade(double grade);
    public virtual Statistics GetStatistics()
    {
        throw new NotImplementedException();
    }

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

public delegate void GradeAddedDelegate(object sender, BookGradeAddedEventArgs args);

public class InMemoryBook : Book
{
    private List<double> grades;

    public InMemoryBook() : base()
    {
        grades = new List<double>();
    }

    public InMemoryBook(string name) : base(name)
    {
        grades = new List<double>();
        Name = name;
    }
    
    public override void AddGrade(double grade)
    {
        if (grade <= 100 && grade >= 0)
        {
            grades.Add(grade);
            if (GradeAdded != null)
            {
                GradeAdded(this, new BookGradeAddedEventArgs(grade));
            }
        }
        else
        {
            throw new ArgumentException($"Invalid {nameof(grade)}; value must be between 0 and 100");
        }
    }
    
    public override event GradeAddedDelegate GradeAdded;

    public void AddLetterGrade(char letter)
    {
        switch (letter)
        {
            case 'A':
                AddGrade(90);
                break;
            
            case 'B':
                AddGrade(80);
                break;
            
            case 'C':
                AddGrade(70);
                break;
            
            case 'D':
                AddGrade(60);
                break;
            
            default:
                AddGrade(0);
                break;
        }
    }

    public override Statistics GetStatistics()
    {
        Statistics stats = new Statistics();
        stats.Average = 0.0;
        stats.High = double.MinValue;
        stats.Low = double.MaxValue;
        
        foreach (double grade in grades)
        {
            stats.Average += grade;
            stats.High = Math.Max(stats.High, grade);
            stats.Low = Math.Min(stats.Low, grade);
        }

        if (grades.Count > 0)
        {
            stats.Average /= grades.Count;
        }

        switch (stats.Average)
        {
            case double grade when grade >= 90.0:
                stats.Letter = 'A';
                break;
            
            case double grade when grade >= 80.0:
                stats.Letter = 'B';
                break;
            
            case double grade when grade >= 70.0:
                stats.Letter = 'C';
                break;
            
            case double grade when grade >= 60.0:
                stats.Letter = 'D';
                break;
            
            default:
                stats.Letter = 'F';
                break;
        }
        
        return stats;
    }

    public override void DisplayGrades()
    {
        string gradeStr;
        int displayedGrades = 20;
        if (grades.Count > displayedGrades)
        {
            gradeStr = String.Join(", ", grades[0..displayedGrades]);
        }
        else
        {
            displayedGrades = grades.Count;
            gradeStr = String.Join(", ", grades);
        }

        Console.WriteLine($"Grades: {gradeStr}");
        Console.WriteLine($"Displaying {displayedGrades}/{grades.Count} grades");
    }
}

public class BookGradeAddedEventArgs : EventArgs
{
    public double Grade { get; }

    public BookGradeAddedEventArgs(double grade)
    {
        Grade = grade;
    }
}