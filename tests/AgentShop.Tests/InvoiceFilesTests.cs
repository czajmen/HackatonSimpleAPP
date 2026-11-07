using AgentShop.Files;

namespace AgentShop.Tests;

public class InvoiceFilesTests : IDisposable
{
    private readonly string root = Directory.CreateTempSubdirectory("invoices").FullName;

    public void Dispose() => Directory.Delete(root, recursive: true);

    [Fact]
    public void Read_returns_the_file_content()
    {
        File.WriteAllText(Path.Combine(root, "inv-1.txt"), "total: 10");

        var content = new InvoiceFiles(root).Read("inv-1.txt");

        Assert.Equal("total: 10", System.Text.Encoding.UTF8.GetString(content!));
    }

    [Fact]
    public void Read_returns_null_for_a_missing_file()
    {
        Assert.Null(new InvoiceFiles(root).Read("missing.txt"));
    }
}
