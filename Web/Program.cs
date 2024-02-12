namespace Web;
using Web.Middleware;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.UseMiddleware<MyAuth>();
        app.Run(async context =>
        {
            await context.Response.WriteAsync("Autherized");
        });

        app.Run();
    }
}
