namespace Gradebook;

public class Book
{
    private List<double> grades;

    public Book()
    {
        grades = new List<double>();
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
        
        stats.average = CalculateAverageGrade();
        stats.high = CalculateHighestGrade();
        stats.low = CalculateLowestGrade();
        
        return stats;
    }
    
    public double CalculateHighestGrade()
    {
        double highestGrade = grades.Max();
        return highestGrade;
    }

    public double CalculateLowestGrade()
    {
        double lowestGrade = grades.Min();
        return lowestGrade;
    }

    public double CalculateAverageGrade()
    {
        double averageGrade = grades.Average();
        return averageGrade;
    }
}