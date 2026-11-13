using AgentShop.Payments;

namespace AgentShop.Tests;

public class PaymentClientTests
{
    [Fact]
    public void AuthorizationHeader_uses_the_supplied_credential()
    {
        var header = new PaymentClient("test-payment-key").AuthorizationHeader;

        Assert.Equal("Bearer test-payment-key", header);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Missing_credentials_are_rejected(string? apiKey)
    {
        Assert.ThrowsAny<ArgumentException>(() => new PaymentClient(apiKey!));
    }

    [Fact]
    public void IsAdmin_rejects_a_wrong_password()
    {
        Assert.False(new PaymentClient("test-payment-key").IsAdmin("not-the-password"));
    }
}
