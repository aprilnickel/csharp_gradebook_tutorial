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
        
        return stats;
    }
}