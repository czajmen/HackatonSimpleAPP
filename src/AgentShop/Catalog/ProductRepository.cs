using Microsoft.Data.Sqlite;

namespace AgentShop.Catalog;

public record Product(long Id, string Name, decimal Price);

public class ProductRepository(SqliteConnection connection)
{
    public void Seed(params Product[] products)
    {
        using var create = connection.CreateCommand();
        create.CommandText = "CREATE TABLE IF NOT EXISTS products (id INTEGER PRIMARY KEY, name TEXT NOT NULL, price REAL NOT NULL)";
        create.ExecuteNonQuery();

        foreach (var product in products)
        {
            using var insert = connection.CreateCommand();
            insert.CommandText = "INSERT INTO products (id, name, price) VALUES ($id, $name, $price)";
            insert.Parameters.AddWithValue("$id", product.Id);
            insert.Parameters.AddWithValue("$name", product.Name);
            insert.Parameters.AddWithValue("$price", (double)product.Price);
            insert.ExecuteNonQuery();
        }
    }

    public List<Product> SearchByName(string name)
    {
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT id, name, price FROM products WHERE name = $name";
        command.Parameters.AddWithValue("$name", name);

        var products = new List<Product>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            products.Add(new Product(reader.GetInt64(0), reader.GetString(1), (decimal)reader.GetDouble(2)));
        }
        return products;
    }
}
