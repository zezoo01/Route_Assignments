namespace ShopMaster.Exercises;

public class Exercise4_UniqueEmailValidator
{
    public static void Run()
    {
        Console.WriteLine("\n Exercise 4: Unique Email Validator \n");

        // 1. Create HashSet with case-insensitive comparer
        HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // 2. Add emails (some are duplicates differing only in case)
        emails.Add("ahmed@test.com");
        emails.Add("AHMED@test.com");
        emails.Add("sara@test.com");
        emails.Add("Sara@Test.Com");

        // 3. Print Count and explain why
        Console.WriteLine($"Count : {emails.Count}");
        Console.WriteLine("Why 2? Because HashSet ignores duplicates, and the");
        Console.WriteLine("OrdinalIgnoreCase comparer treats ahmed@test.com and");
        Console.WriteLine("AHMED@test.com as the same — same for sara@test.com.\n");

        // 4. Create Set A and Set B
        HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4, 5 };
        HashSet<int> setB = new HashSet<int> { 4, 5, 6, 7, 8 };

        // 5a. UnionWith — all elements from both sets
        HashSet<int> union = new HashSet<int>(setA);
        union.UnionWith(setB);
        Console.WriteLine($"UnionWith     : {string.Join(", ", union)}");

        // 5b. IntersectWith — only elements in both sets
        HashSet<int> intersect = new HashSet<int>(setA);
        intersect.IntersectWith(setB);
        Console.WriteLine($"IntersectWith : {string.Join(", ", intersect)}");

        // 5c. ExceptWith — elements in A but not in B
        HashSet<int> except = new HashSet<int>(setA);
        except.ExceptWith(setB);
        Console.WriteLine($"ExceptWith    : {string.Join(", ", except)}");

        // 6. Check if {1,2} is a subset of Set A
        HashSet<int> subset = new HashSet<int> { 1, 2 };
        Console.WriteLine($"\n{{1,2}} is subset of Set A : {subset.IsSubsetOf(setA)}");
    }
}
