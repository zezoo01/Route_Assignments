namespace ShopMaster.Exercises;

public class Exercise2_Leaderboard
{
    public static void Run()
    {
        Console.WriteLine("\nExercise 2: Leaderboard\n");

        // 1. Add players — SortedDictionary auto-sorts by key (score)
        SortedDictionary<int, string> leaderboard = new SortedDictionary<int, string>();
        leaderboard.Add(500, "Ahmed");
        leaderboard.Add(200, "Sara");
        leaderboard.Add(800, "Ali");
        leaderboard.Add(350, "Mona");

        // 2. Print all entries (auto-sorted by score)
        Console.WriteLine("Leaderboard (sorted by score):");
        foreach (var entry in leaderboard)
            Console.WriteLine($"  {entry.Key} -> {entry.Value}");

        // 3. Access first key and first value
        Console.WriteLine($"\nFirst key   : {leaderboard.Keys.First()}");
        Console.WriteLine($"First value : {leaderboard.Values.First()}");

        // 4. Check if score 500 exists
        Console.WriteLine($"\nScore 500 exists : {leaderboard.ContainsKey(500)}");

        // 5. Safely get player with score 999
        leaderboard.TryGetValue(999, out string? player999);
        Console.WriteLine($"Player with score 999 : {player999 ?? "Not Found"}");

        // 6. Remove player with score 200 and print updated list
        leaderboard.Remove(200);
        Console.WriteLine("\nAfter removing score 200:");
        foreach (var entry in leaderboard)
            Console.WriteLine($"  {entry.Key} -> {entry.Value}");
    }
}
