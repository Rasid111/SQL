using Microsoft.Data.SqlClient;

namespace Ado.net
{
    internal class ProductAdonetRepository : ProductRepository
    {
        public override bool Insert(Product product) {

            string connectionString = "Server=localhost;Database=MyDatabase;User Id=admin;Password=admin;";
            var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(
                cmdText: @$"insert into Teachers ([Name], [Salary], [CountryId]) 
            values	('{product.Name}', {product.Count}, {product.Cost})",
                connection: connection
            );

            int affectedRowsCount = command.ExecuteNonQuery();

            return affectedRowsCount > 0;
        }
        public override IEnumerable<Product> Catalogue() {
            List<Product> products = new List<Product>();
            string connectionString = "Server=localhost;Database=MyDatabase;User Id=admin;Password=admin;";

            var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(
                cmdText: "select count(*) from Products",
                connection: connection
            );
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var CurrentProduct = new Product
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Count = reader.GetInt32(2),
                    Cost = reader.GetDecimal(3)
                };
                products.Add(CurrentProduct);
            }
            return products;
        }
        public override bool UpdateCount(string name, int count) {
            string connectionString = "Server=localhost;Database=MyDatabase;User Id=admin;Password=admin;";

            var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(
                cmdText: $"update Products\n set Count = Count + {count}\n where name = '{name}'",
                connection: connection
            );
            return command.ExecuteNonQuery() > 0;
        }
        public override bool DeleteByName(string name)
        {
            string connectionString = "Server=localhost;Database=MyDatabase;User Id=admin;Password=admin;";

            var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(
                cmdText: $"delete from Products where name = '{name}'",
                connection: connection
            );
            return command.ExecuteNonQuery() > 0;
        }
    }
}
