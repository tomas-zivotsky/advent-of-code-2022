using _1_CalorieCounting;
using Microsoft.Extensions.Configuration;
using Utils.Extensions;

var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, true);

var config = builder.Build();

var path = args.Length >= 1
    ? args.First()
    : config["Input:DefaultPath"] ?? throw new ArgumentException("Default path not found.");

var parser = new InputParser();
var inventories = parser.Parse(path);

var sorted = inventories.OrderByDescending(inventory => inventory.Food.TotalCalories);

var topCount = int.Parse(config["TopCount"] ?? throw new ArgumentException("Top count not found."));
var topInventories = sorted.Take(topCount).ToList();

Console.WriteLine($"Top {topCount} inventories:");
foreach ((Inventory topInventory, int index) in topInventories.WithIndex())
{
    Console.WriteLine($"{index + 1}. {topInventory.Food.TotalCalories} calories.");
}

Console.WriteLine();
Console.WriteLine($"Total calories: {topInventories.Sum(inventory => inventory.Food.TotalCalories)}");

Console.ReadKey();
