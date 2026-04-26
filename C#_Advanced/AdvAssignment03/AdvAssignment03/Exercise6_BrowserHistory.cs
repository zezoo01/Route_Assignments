namespace ShopMaster.Exercises;

public class Exercise6_BrowserHistory
{
    public static void Run()
    {
        Console.WriteLine("\n Exercise 6: Browser History (Undo)\n");

        // Create Stack for browser history
        Stack<string> history = new Stack<string>();

        // 1. Push 5 URLs
        history.Push("google.com");
        history.Push("github.com");
        history.Push("stackoverflow.com");
        history.Push("youtube.com");
        history.Push("claude.ai");

        Console.WriteLine($"History (top = current) : {string.Join(", ", history)}");

        // 2. Peek — current page without removing
        Console.WriteLine($"\nCurrent page (Peek) : {history.Peek()}");

        // 3. Press "back" 3 times using Pop
        Console.WriteLine("\nGoing back 3 times:");
        for (int i = 0; i < 3; i++)
            Console.WriteLine($"  Leaving : {history.Pop()}");

        // 4. Print current page after going back
        Console.WriteLine($"\nCurrent page now : {history.Peek()}");

        // 5. TryPop on empty stack
        history.Pop(); // remove remaining pages
        history.Pop();
        bool success = history.TryPop(out string? page);
        Console.WriteLine($"\nTryPop on empty stack : success={success}, value={page ?? "null"}");
    }
}
