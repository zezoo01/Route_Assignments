using static Demo.DataSources.Source;

namespace Assignment01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Q1
            var result = ProductList.Where(p => p.Category == "Seafood")
                                     .Select(p => new { p.ProductName, p.UnitPrice });
            result.Print();
            #endregion

            #region Q2
            //var result = ProductList.Select(p => p.ProductName);
            //result.Print();
            #endregion

            #region Q3
            //var result = ProductList.OrderBy(p => p.ProductName)
            //                    .Select(p => new { Name = p.ProductName, Price = p.UnitPrice });
            //result.Print();
            #endregion

            #region Q4
            //var result = ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
            //result.Print();
            #endregion

            #region Q5
            //var result = ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");
            //result.Print();
            #endregion

            #region Q6
            //var result = ProductList.Select(p => new
            //{
            //    Name = p.ProductName, 
            //    Price = p.UnitPrice ,
            //    StockStatus = p.UnitsInStock > 0 ? "In Stock" : "Out of Stock"
            //}
            //);
            //result.Print();
            #endregion

            #region Q7
            //var result = ProductList.Select((p,i) =>  $"{i + 1}. {p.ProductName}");
            //result.Print();
            #endregion

            #region Q8
            //var result = ProductList
            //                    .OrderBy(p => p.Category)
            //                    .ThenByDescending(p => p.UnitPrice);

            //result.Print();
            #endregion

            #region Q9
            //var result = ProductList
            //                    .Where(p => p.Category == "Beverages")
            //                    .OrderByDescending(p => p.UnitsInStock)
            //                    .Select(p => new { p.ProductName, p.UnitsInStock });

            //result.Print();
            #endregion

            #region Q10
            #endregion
            #region Q11
            //var result = ProductList
            //                        .Select((p, index) => $"{index + 1}. {p.ProductName}");
            //result.Print();
            #endregion

            #region Q 12 & 13
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            //var result = Arr
            //                .OrderBy(w => w.Length)
            //                .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);

            //result.Print();
            //var result13 = Arr
            //                .Where(w => w.Length > 1 && w[1] == 'i')
            //                .Reverse();
            //result13.Print();
            #endregion


        }
    }
}

public static class Extensions
{
    public static void Print<T>(this IEnumerable<T> values)
    {
        foreach (var item in values)
        {
            Console.WriteLine(item);
        }
    }
}

public class CustomStringComparer : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        throw new NotImplementedException();
    }
}