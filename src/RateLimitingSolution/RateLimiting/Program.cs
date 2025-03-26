namespace RateLimiting;

using RateLimiting.Models;
using System.Threading.RateLimiting;

public class Program
{
    public static void Main(String[] args)
    {

        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        _ = builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        _ = builder.Services.AddOpenApi();

        MyRateLimitOptions myOptions = new();
        builder.Configuration.GetSection(MyRateLimitOptions.MyRateLimit).Bind(myOptions);

        //builder.Services.AddRateLimiter( options =>
        //{
        //    options.AddPolicy<string, AEHRateLimiter>("aeh");
        //    options.RejectionStatusCode = 429;
        //});        

        _ = builder.Services.AddRateLimiter(options =>
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

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            _ = app.MapOpenApi();

            _ = app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "RateLimiting v1");
            });
        }

        _ = app.UseHttpsRedirection();

        _ = app.UseAuthorization();


        _ = app.MapControllers();//.RequireRateLimiting("aeh");


        //// Separate Rate limit for specific Endpoint
        //app.MapGet("/api/hello", () => "Hello World!").RequireRateLimiting("Api");

        //// Seprarate rate limit for specific service Group / subdomain
        //app.MapGroup("/api/orders").RequireRateLimiting("Api");

        _ = app.UseRateLimiter();

        app.Run();
    }
}
