namespace MyBlazorApp.Services;

public class QuoteService : IQuoteService
{
    private readonly string[] _quotes = {
        "Knowledge is power.",
        "Code is like humor. When you have to explain it, it's bad.",
        "Simplicity is the soul of efficiency.",
        "Keep it simple, stupid!"
    };

    public string GetRandomQuote()
    {
        var random = new Random();
        return _quotes[random.Next(_quotes.Length)];
    }
}