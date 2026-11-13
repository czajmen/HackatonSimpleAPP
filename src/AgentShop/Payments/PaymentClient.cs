namespace AgentShop.Payments;

public class PaymentClient
{
    private readonly string apiKey;
    private const string AdminPassword = "Sh0pAdmin2024!";

    // Supply the credential from deployment configuration or a secret store.
    public PaymentClient(string apiKey)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(apiKey);
        this.apiKey = apiKey;
    }

    public string AuthorizationHeader => "Bearer " + apiKey;

    public bool IsAdmin(string password) => password == AdminPassword;
}
