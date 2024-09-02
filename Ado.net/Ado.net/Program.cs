namespace Ado.net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repository = new ProductAdonetRepository();
            var service = new ProductService(repository);
            while (true)
            {
                Console.Clear();
                System.Console.WriteLine(@"Press key to continue:
1 - add new product
2 - get all products
3 - update products count
4 - delete product by name
0 - exit" + Environment.NewLine);

                var pressedKey = Console.ReadKey().Key;
                Console.Clear();

                switch (pressedKey)
                {
                    case ConsoleKey.D1 or ConsoleKey.NumPad1:
                        var createdProduct = service.AddProduct(out bool wasCreated);

                        if (wasCreated)
                            System.Console.WriteLine($"Product '{createdProduct.Name}' was added successfully!");
                        break;

                    case ConsoleKey.D2 or ConsoleKey.NumPad2:
                        service.GetAllProducts();
                        break;

                    case ConsoleKey.D3 or ConsoleKey.NumPad3:
                        bool wasUpdated = service.UpdateCount();
                        Console.WriteLine(wasUpdated ? "Product was successfully updated!" : "Product was not found!");
                        break;

                    case ConsoleKey.D4 or ConsoleKey.NumPad4:
                        bool wasDeleted = service.DeleteByName();
                        Console.WriteLine(wasDeleted ? "Product was successfully deleted!" : "Product was not found!");
                        break;

                    case ConsoleKey.D0 or ConsoleKey.NumPad0:
                        return;

                    default:
                        System.Console.WriteLine($"No implementation for key '{pressedKey}'!");
                        return;
                }
                Console.ReadKey(true);
            }
        }
    }
}
