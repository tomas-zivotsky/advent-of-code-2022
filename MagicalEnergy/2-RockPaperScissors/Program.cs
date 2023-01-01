using _2_RockPaperScissors;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, true);

var config = builder.Build();

var path = args.Length >= 1
    ? args.First()
    : config["Input:DefaultPath"] ?? throw new ArgumentException("Default path not found.");

var parser = new InputParser();
var guide = parser.Parse(path);

var item = guide.First();

Console.WriteLine($"{item.Item1}-{item.Item2}");
Console.ReadKey();
