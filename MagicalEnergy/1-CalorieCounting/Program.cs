using _1_CalorieCounting;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, true);

var config = builder.Build();

var path = args.Length >= 1
    ? args.First()
    : config["Input:DefaultPath"] ?? throw new ArgumentException("Default path not found.");

var parser = new InputParser();
var inventories = parser.Parse(path);

var max = inventories.Max(inventory => inventory.Food.TotalCalories);

Console.WriteLine(max);

Console.ReadKey();
