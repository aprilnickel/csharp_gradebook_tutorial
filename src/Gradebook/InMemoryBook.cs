namespace Gradebook;

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
        foreach (double grade in grades)
        {
            stats.AddGrade(grade);
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