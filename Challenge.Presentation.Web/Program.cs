using Challenge.ClientConnector;
using Challenge.ClientConnector.Contracts;

namespace Challenge.Presentation.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient<IChallengeServiceConnector, ChallengeServiceConnector>()
              .ConfigureHttpClient(client => client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("API") ?? throw new Exception("API address is null")));

            Console.WriteLine($"API ADDRESS {builder.Configuration.GetValue<string>("API")}");

            var app = builder.Build();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}