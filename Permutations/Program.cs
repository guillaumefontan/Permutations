using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Permutations
{
    public static class Program
    { 
        static async Task Main()
        {

            var services = new ServiceCollection()
                .AddSingleton<IPermutations, Permutations>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            IPermutations permutations = serviceProvider.GetService<IPermutations>();

            await permutations.Run();
        }
    }
}
