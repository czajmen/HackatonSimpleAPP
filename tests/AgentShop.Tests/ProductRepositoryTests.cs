using AgentShop.Catalog;
using Microsoft.Data.Sqlite;

namespace AgentShop.Tests;

public class ProductRepositoryTests
{
    private static ProductRepository CreateRepository()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();
        var repository = new ProductRepository(connection);
        repository.Seed(new Product(1, "Mouse", 19.90m), new Product(2, "Keyboard", 49.00m));
        return repository;
    }

    [Fact]
    public void SearchByName_finds_an_exact_match()
    {
        var found = CreateRepository().SearchByName("Mouse");

        Assert.Equal(new[] { new Product(1, "Mouse", 19.90m) }, found);
    }

    [Theory]
    [InlineData("' OR 1=1 --")]
    [InlineData("Mouse' OR '1'='1")]
    public void SearchByName_does_not_execute_SQL_in_names(string name)
    {
        Assert.Empty(CreateRepository().SearchByName(name));
    }

    [Fact]
    public void SearchByName_matches_names_containing_quotes()
    {
        var repository = CreateRepository();
        var product = new Product(3, "Owner's Mouse", 25m);
        repository.Seed(product);

        Assert.Equal(new[] { product }, repository.SearchByName(product.Name));
    }

    [Fact]
    public void SearchByName_returns_nothing_for_unknown_name()
    {
        Assert.Empty(CreateRepository().SearchByName("Monitor"));
    }
}
