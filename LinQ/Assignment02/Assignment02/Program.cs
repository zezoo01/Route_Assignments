using static Demo.DataSources.Source;

namespace Assignment02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q01
            //var result = ProductList.OrderByDescending(p => p.UnitPrice)
            //                        .ThenBy(p => p.ProductName)
            //                        .Select(p => new { p.ProductName, p.UnitPrice })
            //                        .Take(3);

            //result.Print();

            #endregion

            #region Q02

            //int pageNumber = 2;
            //int pageSize = 5;

            //var result2 = ProductList.Skip((pageNumber - 1) * pageSize)
            //                         .Take(pageSize);
            //result2.Print();
            #endregion

            #region Q03
            //var result3 = ProductList.OrderBy(p => p.UnitPrice)
            //                         .TakeWhile(p => p.UnitPrice < 25);
            //result3.Print();

            #endregion

            #region Q04
            //var result4 = ProductList.All(p => p.Category == "Seafood");
            //Console.WriteLine(result4);
            #endregion

            #region Q05
            //int[] ids = { 3, 9, 13, 18 };
            //var result5 = ids.Contains(9);
            //Console.WriteLine(result5);
            #endregion

            #region Q06
            //var result6 = ProductList.GroupBy(p => p.Category)
            //                         .Select(p => new { Category = p.Key, Count = p.Count() });

            //foreach (var group in result6)
            //{
            //    Console.WriteLine($"{group.Category} - {group.Count}");
            //}


            #endregion

            #region Q07
            var result7 = ProductList.GroupBy(p => p.Category)
                                      .Select(g => new
                                      {
                                          Category = g.Key,
                                          Product = g.Select(p => p.ProductName)
                                      });
            result7.Print();
            #endregion

            #region Q08
            //var result8 = ProductList.GroupBy(p => p.Category)
            //                          .Where(g => g.Count() > 3)
            //                          .Select(g => g.Key);
            //result8.Print();
            //#endregion

            //#region Q09

            //var result9 = from c in CustomerList
            //            group c by c.Country into g
            //            select new
            //            {
            //                Country = g.Key,
            //                Count = g.Count(),
            //                TotalOrderValue = g.Sum(c => c.Orders.Sum(o => o.Total))
            //            };

            //foreach (var item in result9)
            //{
            //    Console.WriteLine($"{item.Country} - {item.Count} customers - Total: {item.TotalOrderValue}");
            //}
            #endregion

            #region Q10
            var totalUnits = ProductList.Sum(p => p.UnitsInStock);
            Console.WriteLine(totalUnits);
            #endregion

            #region Q11
            var minPrice = ProductList.Min(p => p.UnitPrice);
            var maxPrice = ProductList.Max(p => p.UnitPrice);

            Console.WriteLine($"Min Price: {minPrice:C2}, Max Price: {maxPrice:C2}");
            #endregion

            #region Q12
            var categories = ProductList
                                        .Select(p => p.Category)
                                        .Distinct();
            categories.Print();
            #endregion

            #region Q13

            #endregion

            #region Q14

            #endregion

            #region Q15
            var dict = ProductList.ToDictionary(p => p.ProductID);

            var product = dict[18];

            Console.WriteLine(product.ProductName);

            #endregion

            #region Q16
            var prod = ProductList.First(p => p.UnitPrice > 50);
            Console.WriteLine(prod.ProductName);
            #endregion

            #region Q17
            var produ = ProductList.FirstOrDefault(p => p.UnitPrice > 500);
            Console.WriteLine(prod.ProductName);
            #endregion

            #region Q18
            var result18 = Enumerable.Range(1, 10)
                                   .Select(x => 7 * x);
            result18.Print();
            #endregion

            #region Q19
            var evens = Enumerable.Range(1, 30)
                                  .Where(x => x % 2 == 0);
            evens.Print();
            #endregion

            #region Q20
            var result20 = ProductList
                                    .Select(p => p.ProductName).Take(3)
                                    .Concat(CustomerList.Select(c => c.CompanyName).Take(3));
            result20.Print();
            #endregion

            #region Q21
            var result21 = ProductList
                            .Zip(CustomerList,
                                (p, c) => $"{p.ProductName} sold to {c.CompanyName}");

            result21.Print();
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
