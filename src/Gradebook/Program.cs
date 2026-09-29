using System.Text.RegularExpressions;

namespace Gradebook;

class Program
{
    static void Main(string[] args)
    {
        var book = new InMemoryBook();
        book.GradeAdded += OneGradeAdded;

        bool isRun = true;

        do
        {
            DisplayMainMenu(book);
            char selectedOption = GetValidMainMenuSelection();
            
            switch (selectedOption)
            {
                case 'A':
                    AddNumberGrade(book);
                    break;
                case 'D':
                    DisplayGrades(book);
                    break;
                case 'S':
                    DisplayStatistics(book);
                    break;
                case 'N':
                    ChangeName(book);
                    break;
                case 'Q':
                    isRun = false;
                    break;
            }
        } while (isRun);
    }

    static void DisplayMainMenu(Book book)
    {
        Console.Clear();
        Console.WriteLine($"Welcome to your Grade Book '{book.Name}'. Please select an option.");
        Console.WriteLine("A   Add a grade (number between 0-100)");
        Console.WriteLine("D   Display grades");
        Console.WriteLine("S   Display grade book statistics");
        Console.WriteLine("N   Change grade book name");
        Console.WriteLine("Q   Quit");
    }

    static char GetValidMainMenuSelection()
    {
        string validOptions = "^[aAdDlLnNqQsS]$";
        bool isValidSelection = false;
        char selectedOption = 'Q';
        do
        {
            string input = Console.ReadLine();
            bool isMatch = Regex.IsMatch(input, validOptions);
            if (input.Length == 0 || input.Length > 1 || !isMatch)
            {
                Console.WriteLine("Please select an option by typing the corresponding letter, then press Enter.");
            }
            else
            {
                input = input.ToUpper();
                selectedOption = input[0];
                isValidSelection = true;
            }
        } while (!isValidSelection);

        return selectedOption;
    }

    static void AddNumberGrade(Book book)
    {
        bool isRun = true;
        string validOptions = @"^([qQ]|\d+)$";
        double newGrade;
        Console.Clear();

        do
        {
            Console.WriteLine("Enter a new grade, or enter Q to Quit to Main Menu");
            string input = Console.ReadLine();
            bool isMatch = Regex.IsMatch(input, validOptions);
            if (!isMatch)
            {
                Console.WriteLine("Please enter a valid grade, then press Enter.");
                continue;
            }
            
            if (input == "Q" || input == "q")
            {
                isRun = false;
                continue;
            }
            
            try
            {
                newGrade = double.Parse(input);
                book.AddGrade(newGrade);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
            
        } while (isRun);
    }

    static void OneGradeAdded(object sender, BookGradeAddedEventArgs eventArgs)
    {
        Console.WriteLine($"Grade added: {eventArgs.Grade}");
    }

    static void DisplayGrades(Book book)
    {
        Console.Clear();
        book.DisplayGrades();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void DisplayStatistics(Book book)
    {
        Console.Clear();
        book.DisplayStatistics();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void ChangeName(Book book)
    {
        bool isRun = true;
        do
        {
            Console.WriteLine($"Current name: {book.Name}");
            Console.WriteLine("Enter a new name for your grade book, or enter Q to Quit to Main Menu");
            string input = Console.ReadLine();
            
            if (input == "Q" || input == "q")
            {
                isRun = false;
                continue;
            }
            
            try
            {
                book.Name = input;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
            
            isRun = false;
        } while (isRun);
    }
}
