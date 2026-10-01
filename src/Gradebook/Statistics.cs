namespace Gradebook;

public class Statistics
{
    public int Count = 0;
    public double Sum = 0.0;
    public double Average
    {
        get
        {
            if (Count > 0)
            {
                return Sum / Count;
            }

            return 0;
        }
    }
    public double High = double.MinValue;
    public double Low = double.MaxValue;

    public char Letter
    {
        get
        {
            switch (Average)
            {
                case double grade when grade >= 90.0:
                    return 'A';

                case double grade when grade >= 80.0:
                    return 'B';

                case double grade when grade >= 70.0:
                    return 'C';

                case double grade when grade >= 60.0:
                    return 'D';

                default:
                    return 'F';
            }
        }
    }

    public void AddGrade(double newGrade)
    {
        Count++;
        Sum += newGrade;
        High = Math.Max(High, newGrade);
        Low = Math.Min(Low, newGrade);
    }
}