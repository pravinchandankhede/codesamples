namespace RateLimiting;

using Microsoft.Extensions.Options;
using RateLimiting.Models;
using RateLimiting.RateLimiter;
using System.Threading.RateLimiting;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var myOptions = new MyRateLimitOptions();
        builder.Configuration.GetSection(MyRateLimitOptions.MyRateLimit).Bind(myOptions);

        //builder.Services.AddRateLimiter( options =>
        //{
        //    options.AddPolicy<string, AEHRateLimiter>("aeh");
        //    options.RejectionStatusCode = 429;
        //});        

        builder.Services.AddRateLimiter(options =>
        {
            //options.AddPolicy("Api", httpContext =>
            //    RateLimitPartition.GetFixedWindowLimiter(httpContext.Request.Host,
            //    partition => new FixedWindowRateLimiterOptions
            //    {
            //        AutoReplenishment = true,
            //        PermitLimit = 10,
            //        Window = TimeSpan.FromSeconds(1)
            //    }));

            options.GlobalLimiter = PartitionedRateLimiter.CreateChained(
                PartitionedRateLimiter.Create<HttpContext, String>(httpContext =>
                    RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Host.ToString(),
                        factory: partition => new FixedWindowRateLimiterOptions
                        {
                            AutoReplenishment = myOptions.AutoReplenishment,
                            PermitLimit = myOptions.PermitLimit,
                            QueueLimit = 10,
                            Window = TimeSpan.FromSeconds(myOptions.Window)
                        })),
                PartitionedRateLimiter.Create<HttpContext, String>(httpContext =>
                    RateLimitPartition.GetConcurrencyLimiter(
                         partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Host.ToString(),
                         factory: partition => new ConcurrencyLimiterOptions
                         {
                             PermitLimit = myOptions.PermitLimit,
                             QueueLimit = myOptions.QueueLimit
                         }))
            );

            //options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, String>(httpContext =>
            //        RateLimitPartition.GetFixedWindowLimiter(
            //            partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Host.ToString(),
            //            factory: partition => new FixedWindowRateLimiterOptions
            //            {
            //                AutoReplenishment = myOptions.AutoReplenishment,
            //                PermitLimit = myOptions.PermitLimit,
            //                //QueueLimit = 10,
            //                Window = TimeSpan.FromSeconds(myOptions.Window)
            //            }));

            options.RejectionStatusCode = 429;
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "RateLimiting v1");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();//.RequireRateLimiting("aeh");


        //// Separate Rate limit for specific Endpoint
        //app.MapGet("/api/hello", () => "Hello World!").RequireRateLimiting("Api");

        //// Seprarate rate limit for specific service Group / subdomain
        //app.MapGroup("/api/orders").RequireRateLimiting("Api");

        app.UseRateLimiter();

        app.Run();
    }
}
