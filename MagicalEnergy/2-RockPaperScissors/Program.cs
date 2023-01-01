using _2_RockPaperScissors;
using Microsoft.Extensions.Configuration;
using Utils.Helpers;

var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, true);

var config = builder.Build();

var path = args.Length >= 1
    ? args.First()
    : config["Input:DefaultPath"] ?? throw new ArgumentException("Default path not found.");

var fileHelper = new FileHelper();

var parser = new InputParser(fileHelper);
var evaluator = new Evaluator();

var guideResponses = parser.Parse<Choice, Response>(path);

int totalScore = 0;
foreach ((Choice choice, Response response) in guideResponses)
{
    totalScore += evaluator.Evaluate(choice, response);
}

Console.WriteLine($"#1: Total score is: {totalScore}.");

var guideResults = parser.Parse<Choice, Result>(path);

totalScore = 0;
foreach ((Choice choice, Result result) in guideResults)
{
    totalScore += evaluator.Evaluate(choice, result);
}

Console.WriteLine($"#2: Total score is: {totalScore}.");

Console.ReadKey();
