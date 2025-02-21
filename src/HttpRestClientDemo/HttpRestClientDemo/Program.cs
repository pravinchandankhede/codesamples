namespace HttpRestClientDemo;

using System;
using System.Net.Http;
using System.Threading.Tasks;

/// <summary>
/// This is simple demo of how to make a GET request to a REST API using HttpClient.
/// </summary>
class Program
{
    static async Task Main()
    {
        var apiUrl = "https://pcgitmfapi.azurewebsites.net/api/staff";
        var client = new HttpClient();

        try
        {
            // Make a GET request to the API
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            // Read the response content
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Response received from API:");
            Console.WriteLine(responseBody);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("Request error:");
            Console.WriteLine(e.Message);
        }
    }
}
