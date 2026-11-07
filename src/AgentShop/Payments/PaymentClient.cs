namespace AgentShop.Payments;

public class PaymentClient
{
    private const string ApiKey = "agentshop-pay-7f3a9c21d84e5b60a1c2";
    private const string AdminPassword = "Sh0pAdmin2024!";

    public string AuthorizationHeader => "Bearer " + ApiKey;

    public bool IsAdmin(string password) => password == AdminPassword;
}
