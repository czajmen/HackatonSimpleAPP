using AgentShop.Payments;

namespace AgentShop.Tests;

public class PaymentClientTests
{
    [Fact]
    public void AuthorizationHeader_is_a_bearer_token()
    {
        var header = new PaymentClient().AuthorizationHeader;

        Assert.StartsWith("Bearer ", header);
        Assert.True(header.Length > "Bearer ".Length);
    }

    [Fact]
    public void IsAdmin_rejects_a_wrong_password()
    {
        Assert.False(new PaymentClient().IsAdmin("not-the-password"));
    }
}
