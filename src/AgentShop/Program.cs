// AgentShop — szkielet sklepu z asystentem AI (repo demonstracyjne SupplyGuard).
// Aplikacja celowo nic nie robi; istnieje po to, żeby repo miało realistyczne manifesty zależności.

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "AgentShop demo");
app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.Run();
