namespace BankingService;

using Microsoft.AspNetCore.Server.Kestrel.Https;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure Kestrel for mTLS
        builder.WebHost.ConfigureKestrel(options =>
        {
            options.ConfigureHttpsDefaults(httpsOptions =>
            {
                httpsOptions.ServerCertificate = new X509Certificate2("server.pfx", "YourPassword123");
                
                // Require client certificates
                httpsOptions.ClientCertificateMode = ClientCertificateMode.RequireCertificate;

                // (Optional) Add custom certificate validation
                httpsOptions.ClientCertificateValidation = (certificate, chain, errors) =>
                {
                    // Example: accept all valid certificates
                    return errors == System.Net.Security.SslPolicyErrors.None;
                    // For production, implement proper validation here
                };
            });
        });

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        // Add certificate authentication middleware
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
