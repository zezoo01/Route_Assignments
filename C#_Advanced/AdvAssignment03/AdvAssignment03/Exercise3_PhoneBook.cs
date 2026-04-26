namespace ShopMaster.Exercises;

public class Exercise3_PhoneBook
{
    public static void Run()
    {
        Console.WriteLine("\n Exercise 3: Phone Book \n");

        // 1. Create Dictionary with 4 contacts
        Dictionary<string, string> phoneBook = new Dictionary<string, string>
        {
            { "Ahmed", "010-1234-5678" },
            { "Sara",  "011-2345-6789" },
            { "Ali",   "012-3456-7890" },
            { "Mona",  "015-4567-8901" }
        };

        // 2. Add a new contact using [] syntax (adds or updates)
        phoneBook["Khaled"] = "010-9999-0000";
        Console.WriteLine("Added Khaled using [] syntax.");

        // 3. Try adding a duplicate using .Add() — catch the exception
        try
        {
            phoneBook.Add("Ahmed", "000-0000-0000");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Add() error : {ex.Message}");
        }

        // 4. Try adding a duplicate using .TryAdd()
        bool added = phoneBook.TryAdd("Sara", "000-0000-0000");
        Console.WriteLine($"TryAdd duplicate 'Sara' succeeded : {added}");

        // 5. Search for a contact that doesn't exist
        bool exists = phoneBook.ContainsKey("Omar");
        Console.WriteLine($"'Omar' exists : {exists}");

        // 6. Get a contact with a fallback of "Not Found"
        phoneBook.TryGetValue("Omar", out string? omarPhone);
        Console.WriteLine($"Omar's phone : {omarPhone ?? "Not Found"}");

        // 7. Print all Keys on one line, then all Values on another
        Console.WriteLine($"\nKeys   : {string.Join(", ", phoneBook.Keys)}");
        Console.WriteLine($"Values : {string.Join(", ", phoneBook.Values)}");
    }
}
