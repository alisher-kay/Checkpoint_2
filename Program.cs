List<Product> products = new List<Product>();

Console.WriteLine("PRODUCT ENTRY");

while (true)
{
    Console.Write("Enter category (or 'q' to quit): ");
    string categoryName = Console.ReadLine();
    if (categoryName.ToLower() == "q") break;

    Console.Write("Enter product name (or 'q' to quit): ");
    string productName = Console.ReadLine();
    if (productName.ToLower() == "q") break;

    Console.Write("Enter price (or 'q' to quit): ");
    string priceInput = Console.ReadLine();
    if (priceInput.ToLower() == "q") break;

    if (!decimal.TryParse(priceInput, out decimal price))
    {
        Console.WriteLine("Invalid price. Try again.\n");
        continue;
    }

    Category category = new Category(categoryName);
    Product product = new Product(productName, category, price);
    products.Add(product);

    Console.WriteLine("Product added!\n");
}

if (products.Count == 0)
{
    Console.WriteLine("No products entered.");
    return;
}

Console.WriteLine("\nSORTED PRODUCT LIST");

var sortedProducts = products.OrderBy(p => p.Price).ToList();

Console.WriteLine("{0,-15} | {1,-20} | {2,8}", "Category", "Product", "Price");
Console.WriteLine(new string('-', 50));

foreach (var p in sortedProducts)
{
    Console.WriteLine("{0,-15} | {1,-20} | {2,6} SEK", p.Category.Name, p.Name, p.Price);
}

decimal total = sortedProducts.Sum(p => p.Price);
Console.WriteLine(new string('-', 50));
Console.WriteLine($"Total price: {total} SEK");

Console.ReadLine();

class Category
{
    public string Name { get; set; }
    public Category(string name)
    {
        Name = name;
    }
}

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
    public Product(string name, Category category, decimal price)
    {
        Name = name;
        Price = price;
        Category = category;
    }
}








