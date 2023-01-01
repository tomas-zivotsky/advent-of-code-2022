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

var evaluator = new Evaluator();
int totalScore = 0;

foreach ((Choice choice, Response response) in guide)
{
    totalScore += evaluator.Evaluate(choice, response);
}

Console.WriteLine($"Total score is: {totalScore}.");

Console.ReadKey();
