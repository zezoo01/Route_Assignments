using ShopMaster.Models;

namespace ShopMaster.Services;

// Task 01 : Smart Product Search
// All search-related logic lives here.
public class ProductSearch
{
    // Delegate used: Func<Product, bool>
    // Why: We need a flexible filter condition that takes a Product
    //      and returns true/false. Func<Product, bool> lets the caller
    //      pass any filter without changing this method.
    public static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
    {
        List<Product> result = new List<Product>();
        foreach (var p in products)
            if (filter(p)) result.Add(p);
        return result;
    }
}
