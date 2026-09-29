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
