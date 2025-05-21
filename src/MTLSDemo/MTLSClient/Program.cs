using System.Security.Cryptography.X509Certificates;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting MTLS client...");

        // Specify your client certificate file and password.
        string clientCertPath = "path/to/your/client.pfx";
        string clientCertPassword = "yourPassword";

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

        try
        {
            // Replace with your actual API endpoint.
            string apiUrl = "https://localhost:5001/api/accounts/12345";
            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var accountDetails = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Account Details: " + accountDetails);
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
