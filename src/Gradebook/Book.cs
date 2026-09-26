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
        stats.average = 0.0;
        stats.high = double.MinValue;
        stats.low = double.MaxValue;
        
        foreach (double grade in grades)
        {
            stats.average += grade;
            stats.high = Math.Max(stats.high, grade);
            stats.low = Math.Min(stats.low, grade);
        }

        if (grades.Count > 0)
        {
            stats.average /= grades.Count;
        }
        
        return stats;
    }
}