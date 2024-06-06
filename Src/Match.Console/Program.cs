using Match.Core;
using Match.Core.Enums;
using Match.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Default;

        using IHost host = CreateHostBuilder(args).Build();
        using var scope = host.Services.CreateScope();
        var matchGame = scope.ServiceProvider.GetRequiredService<IMatchGame>();

        var allowedConditionValues = Enum.GetValues<MatchCondition>().Select(x => (int)x);

        var packQuantity = 0;
        var matchCondition = 0;

        do
        {
            Console.WriteLine("How many packs do you want to add to the deck use?");
        }
        while (!(int.TryParse(Console.ReadLine(), out packQuantity) && packQuantity != 0));

        do
        {
            Console.WriteLine("What match condition do you want to use, enter number:");

            foreach (var item in Enum.GetValues(typeof(MatchCondition)))
            {
                Console.WriteLine($"{(int)item} - {((MatchCondition)item).ToSentenceCase()}");
            }
        }
        while (!(int.TryParse(Console.ReadLine(), out matchCondition) && allowedConditionValues.Contains(matchCondition) && matchCondition != 0));

        matchGame.Play(packQuantity, matchCondition);
    }

    static IHostBuilder CreateHostBuilder(string[] strings)
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((_, services) =>
            {
                services.AddSingleton<IMatchGame, MatchGame>();
                services.AddSingleton<IRandomProvider, RandomProvider>();
            });
    }
}