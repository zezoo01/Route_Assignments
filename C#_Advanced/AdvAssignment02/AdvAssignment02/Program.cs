using ShopMaster.Models;
using ShopMaster.Services;

//Product Catalog (Starter Data)

List<Product> products = new List<Product>
{
    new Product("Laptop",       "Electronics", 1200, 15),
    new Product("Phone",        "Electronics",  800, 30),
    new Product("T-Shirt",      "Clothing",      25, 50),
    new Product("Jeans",        "Clothing",      60, 40),
    new Product("Headphones",   "Electronics",  150,  0),
    new Product("Book",         "Education",     20, 100),
    new Product("Desk",         "Furniture",    350,  8),
    new Product("Coffee Maker", "Appliances",    75, 20),
    new Product("Jacket",       "Clothing",      90, 25),
    new Product("Tablet",       "Electronics",  500,  5),
};


//TASK 01 : Smart Product Search

Console.WriteLine("========== TASK 01 : Smart Product Search ==========\n");

Console.WriteLine("--- Electronics ---");
var electronics = ProductSearch.SearchProducts(products, p => p.Category == "Electronics");
foreach (var p in electronics)
    Console.WriteLine($"{p.Name} - ${p.Price}");

Console.WriteLine("\n--- Cheaper than $50 ---");
var cheap = ProductSearch.SearchProducts(products, p => p.Price < 50);
foreach (var p in cheap)
    Console.WriteLine($"{p.Name} - ${p.Price}");

Console.WriteLine("\n--- In Stock ---");
var inStock = ProductSearch.SearchProducts(products, p => p.Stock > 0);
foreach (var p in inStock)
    Console.WriteLine($"{p.Name} - Stock: {p.Stock}");

Console.WriteLine("\n--- Clothing under $100 ---");
var clothingUnder100 = ProductSearch.SearchProducts(products, p => p.Category == "Clothing" && p.Price < 100);
foreach (var p in clothingUnder100)
    Console.WriteLine($"{p.Name} - ${p.Price}");


//  TASK 03 : Custom Report Generator

Console.WriteLine("\n========== TASK 03 : Custom Report Generator ==========\n");

// 3.1 PrintReport
Console.WriteLine("--- Scenario 1 : Short Report ---");
ReportService.PrintReport(products, p => Console.WriteLine($"{p.Name} - ${p.Price}"));

Console.WriteLine("\n--- Scenario 2 : Detailed Report ---");
ReportService.PrintReport(products, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));

// 3.2 TransformProducts
Console.WriteLine("\n--- Scenario 3 : Summary List ---");
var summaries = ReportService.TransformProducts(products, p => $"{p.Name} (${p.Price})");
foreach (var s in summaries)
    Console.WriteLine(s);

Console.WriteLine("\n--- Scenario 4 : Price Label ---");
var labels = ReportService.TransformProducts(products, p => $"{p.Name}: {(p.Price > 100 ? "Expensive!" : "Affordable")}");
foreach (var l in labels)
    Console.WriteLine(l);

// 3.3 FilterProducts
Console.WriteLine("\n--- Scenario 5 : Low-Stock Alert ---");
var lowStock = ReportService.FilterProducts(products, p => p.Stock < 20);
foreach (var p in lowStock)
    Console.WriteLine($"[LOW STOCK] {p.Name}: only {p.Stock} left!");
