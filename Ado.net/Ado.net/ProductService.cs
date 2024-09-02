namespace Ado.net
{
    internal class ProductService
    {
        private readonly ProductRepository repository;
        public ProductService(ProductRepository repository)
        {
            this.repository = repository;
        }
        public Product AddProduct(out bool wasCreated)
        {
            Product product = new Product();
            Console.Write("Product's name: ");
            product.Name = Console.ReadLine()?.Trim() ?? "Unknown";
            Console.Write("Product's count: ");
            product.Count = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Product's cost: ");
            product.Cost = decimal.Parse(Console.ReadLine() ?? "0");
            wasCreated = this.repository.Insert(product);
            return product;
        }
        public void GetAllProducts()
        {
            IEnumerable<Product> products = this.repository.Catalogue();
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
        }
        public bool UpdateCount()
        {
            Console.Write("Product's name: ");
            string? name = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");
            Console.Write("Difference: ");
            int difference = int.Parse(Console.ReadLine() ?? "0");
            return this.repository.UpdateCount(name, difference);
        }
        public bool DeleteByName()
        {
            Console.Write("Product's name: ");
            string? name = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");
            return this.repository.DeleteByName(name);
        }
    }
}
