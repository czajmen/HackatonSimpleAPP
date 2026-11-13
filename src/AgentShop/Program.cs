// AgentShop — szkielet sklepu z asystentem AI (repo demonstracyjne SupplyGuard).

using AgentShop.Catalog;
using AgentShop.Files;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var connection = new SqliteConnection("Data Source=:memory:");
connection.Open();
var products = new ProductRepository(connection);
products.Seed(new Product(1, "Mouse", 19.90m), new Product(2, "Keyboard", 49.00m));

var invoices = new InvoiceFiles(Path.Combine(app.Environment.ContentRootPath, "invoices"));

app.MapGet("/", () => "AgentShop demo");
app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapGet("/products", (string name) =>
    Results.Content(JsonConvert.SerializeObject(products.SearchByName(name)), "application/json"));

app.MapGet("/invoices/{fileName}", (string fileName) =>
    invoices.Read(fileName) is { } content ? Results.File(content, "application/octet-stream") : Results.NotFound());

app.Run();
