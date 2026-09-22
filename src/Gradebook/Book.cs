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

    public void ShowStats()
    {
        double highestGrade = CalculateHighestGrade();
        double lowestGrade = CalculateLowestGrade();
        double averageGrade = CalculateAverageGrade();
        
        Console.WriteLine($"Highest grade: {highestGrade}");
        Console.WriteLine($"Lowest grade: {lowestGrade}");
        Console.WriteLine($"Average grade: {averageGrade}");
    }
}