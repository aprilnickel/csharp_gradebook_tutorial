using System.IO;

namespace Gradebook;

public class DiskBook : Book
{
    private const string PATH = @"C:\Users\april\Documents\code\csharp_gradebook_tutorial\output\";
    private string filename
    {
        get
        {
            return $"{Name}.txt";
        }
    }
    
    public override void AddGrade(double grade)
    {
        if (grade <= 100 && grade >= 0)
        {
            using (StreamWriter sw = File.AppendText(PATH + filename))
            {
                sw.WriteLine(grade);
                
                if (GradeAdded != null)
                {
                    GradeAdded(this, new BookGradeAddedEventArgs(grade));
                }
            }
        }
        else
        {
            throw new ArgumentException($"Invalid {nameof(grade)}; value must be between 0 and 100");
        }
    }
    
    public override event GradeAddedDelegate GradeAdded;

    public override Statistics GetStatistics()
    {
        Statistics stats = new Statistics();
        using (StreamReader sr = File.OpenText(PATH + filename))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                stats.AddGrade(double.Parse(line));
            }
        }
        return stats;
    }

    public override void DisplayGrades()
    {
        string gradeStr = "";
        int maxDisplayedGrades = 20;
        int displayedGrades = 0;
        int totalGrades = 0;
        
        using (StreamReader sr = File.OpenText(PATH + filename))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                if (displayedGrades <= maxDisplayedGrades)
                {
                    if (gradeStr.Length > 0)
                    {
                        gradeStr += ", ";
                    }
                    gradeStr += double.Parse(line);
                    displayedGrades++;
                }
                
                totalGrades++;
            }
        }
        
        Console.WriteLine($"Grades: {gradeStr}");
        Console.WriteLine($"Displaying {displayedGrades}/{totalGrades} grades");
    }
}
