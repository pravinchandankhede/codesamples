namespace TestClient;

internal class Program
{
    static async Task Main()
    {
        HttpClient httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://localhost:7146");

        await Parallel.ForAsync(0, 30, async (i, cancellationToken) =>
        {
            try
            {
                var response = await httpClient.GetAsync("WeatherForecast", cancellationToken);
                Console.WriteLine( $"Status Code {response.StatusCode}, ReasonPhrase {response.ReasonPhrase}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }).ConfigureAwait(true);
    }
}
