namespace Gradebook;

public class Book
{
    private List<double> grades;
    public string Name;

    public Book(string name)
    {
        grades = new List<double>();
        Name = name;
    }
    
    public void AddGrade(double grade)
    {
        if (grade <= 100 && grade >= 0)
        {
            grades.Add(grade);
        }
        else
        {
            Console.WriteLine("Invalid value; grade must be between 0 and 100");
        }
    }

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

    public Statistics GetStatistics()
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
}