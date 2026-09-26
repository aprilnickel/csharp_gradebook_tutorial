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
        grades.Add(grade);
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