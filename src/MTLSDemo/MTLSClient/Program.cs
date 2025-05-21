using System.Security.Cryptography.X509Certificates;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Starting MTLS client...");

        // Specify your client certificate file and password.
        string clientCertPath = "client.pfx";
        string clientCertPassword = "ClientPassword123";

        // Load the client certificate.
        var clientCertificate = new X509Certificate2(clientCertPath, clientCertPassword);

        // Configure HttpClientHandler to use the client certificate.
        var handler = new HttpClientHandler();
        handler.ClientCertificates.Add(clientCertificate);

        // In production, validate the server certificate properly.
        // Here the callback is configured to accept any certificate for demo purposes.
        handler.ServerCertificateCustomValidationCallback =
            (httpRequestMessage, cert, cetChain, policyErrors) => true;

        using var httpClient = new HttpClient(handler);
        //using var httpClient = new HttpClient();

        try
        {
            // Replace with your actual API endpoint.
            string apiUrl = "https://localhost:7182/WeatherForecast";
            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var weatherDetails = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Weather Details: " + weatherDetails);
            }
            else
            {
                Console.WriteLine("Error: " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
