namespace Gradebook;

class Program
{
    static void Main(string[] args)
    {
        var book = new Book();
        book.AddGrade(55);
        book.AddGrade(99);
        book.AddGrade(88);
        book.AddGrade(92);
        book.AddGrade(65);
        book.ShowStats();
    }
}
