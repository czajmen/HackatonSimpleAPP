namespace AgentShop.Files;

public class InvoiceFiles(string rootDirectory)
{
    public byte[]? Read(string fileName)
    {
        var path = Path.Combine(rootDirectory, fileName);
        return File.Exists(path) ? File.ReadAllBytes(path) : null;
    }
}
