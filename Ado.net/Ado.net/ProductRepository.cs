namespace Ado.net
{
    internal abstract class ProductRepository
    {
        public abstract bool Insert(Product product);
        public abstract IEnumerable<Product> Catalogue();
        public abstract bool UpdateCount(string name, int count);
        public abstract bool DeleteByName(string name);
    }
}
