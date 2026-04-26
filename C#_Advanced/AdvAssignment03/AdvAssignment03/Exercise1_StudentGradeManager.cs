namespace ShopMaster.Exercises;

public class Exercise1_StudentGradeManager
{
    public static void Run()
    {
        Console.WriteLine("Exercise 1: Student Grade Manager\n");

        // 1. Create a List with grades
        List<int> grades = new List<int> { 85, 92, 78, 95, 88, 70, 100, 65 };

        // 2. Print collection, Count, first and last grade
        Console.WriteLine($"Grades     : {string.Join(", ", grades)}");
        Console.WriteLine($"Count      : {grades.Count}");
        Console.WriteLine($"First grade: {grades.First()}");
        Console.WriteLine($"Last grade : {grades.Last()}");

        // 3. Sort ascending then print
        grades.Sort();
        Console.WriteLine($"\nSorted     : {string.Join(", ", grades)}");

        // 4. Get the first grade above 90
        int firstAbove90 = grades.First(g => g > 90);
        Console.WriteLine($"First above 90 : {firstAbove90}");

        // 5. Get all grades below 75 (failing)
        List<int> failing = grades.Where(g => g < 75).ToList();
        Console.WriteLine($"Failing grades : {string.Join(", ", failing)}");

        // 6. Remove all failing grades
        grades.RemoveAll(g => g < 75);
        Console.WriteLine($"After removing failing : {string.Join(", ", grades)}");

        // 7. Check if any grade equals 100
        bool hasHundred = grades.Any(g => g == 100);
        Console.WriteLine($"Any grade = 100 : {hasHundred}");

        // 8. Transform each grade into "Grade: X"
        List<string> gradeLabels = grades.Select(g => $"Grade: {g}").ToList();
        Console.WriteLine($"Labels : {string.Join(", ", gradeLabels)}");
    }
}
