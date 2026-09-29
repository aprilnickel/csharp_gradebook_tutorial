using System.Text.RegularExpressions;

namespace Gradebook;

class Program
{
    static void Main(string[] args)
    {
        var book = new Book("Grade Book");

        bool isRun = true;

        do
        {
            DisplayMainMenu();
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
                case 'Q':
                    isRun = false;
                    break;
            }
        } while (isRun);
    }

    static void DisplayMainMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to your Grade Book. Please select an option.");
        Console.WriteLine("A   Add a grade (number between 0-100)");
        Console.WriteLine("D   Display grades");
        Console.WriteLine("S   Display grade book statistics");
        Console.WriteLine("Q   Quit");
    }

    static char GetValidMainMenuSelection()
    {
        string validOptions = "^[aAdDlLqQsS]$";
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
        double newGrade = 0;
        bool hasPreviousGrade = false;

        do
        {
            // Console.Clear();
            if (hasPreviousGrade)
            {
                Console.WriteLine($"Grade entered: {newGrade}");
            }
            Console.WriteLine("Enter a new grade, or enter Q to Quit to Main Menu");
            string input = Console.ReadLine();
            bool isMatch = Regex.IsMatch(input, validOptions);
            if (!isMatch)
            {
                Console.WriteLine("Please enter a valid grade, then press Enter.");
                hasPreviousGrade = false;
                continue;
            }
            
            if (input == "Q" || input == "q")
            {
                isRun = false;
            }
            else
            {
                newGrade = double.Parse(input);
                book.AddGrade(newGrade);
                // TODO: add exception on AddGrade error validation to hasPreviousGrade = false & continue
                hasPreviousGrade = true;
            }
            
        } while (isRun);
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
}
