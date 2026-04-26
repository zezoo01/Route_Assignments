using ShopMaster.Models;

namespace ShopMaster.Services;

// Task 03 : Custom Report Generator
// All reporting logic lives here.
public class ReportService
{
    // Task 03.1
    // Delegate used: Action<Product>
    // Why: We want to perform an action on each product but return
    //      nothing. Action<Product> is designed exactly for this.
    public static void PrintReport(List<Product> products, Action<Product> action)
    {
        foreach (var p in products)
            action(p);
    }

    // Task 03.2
    // Delegate used: Func<Product, string>
    // Why: We want to convert each Product into a string value.
    //      Func<Product, string> lets the caller decide the format.
    public static List<string> TransformProducts(List<Product> products, Func<Product, string> transform)
    {
        List<string> result = new List<string>();
        foreach (var p in products)
            result.Add(transform(p));
        return result;
    }

    // Task 03.3
    // Delegate used: Predicate<Product>
    // Why: Predicate<T> is a built-in delegate specifically for
    //      filtering — it takes T and returns bool, more expressive
    //      in intent than Func<Product, bool> when the goal is filtering.
    public static List<Product> FilterProducts(List<Product> products, Predicate<Product> condition)
    {
        List<Product> result = new List<Product>();
        foreach (var p in products)
            if (condition(p)) result.Add(p);
        return result;
    }
}
