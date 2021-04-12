using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace scape
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddSingleton<Model.Game>(new Model.Game(
                new Model.Mob("@", 40, 12),
                new Model.Mob[]
                {
                    new Model.Mob("d", 1, 1),
                }
            ));

            await builder.Build().RunAsync();
        }
    }
}
