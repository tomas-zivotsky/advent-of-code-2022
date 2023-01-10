using _5_SupplyStacks;
using Microsoft.Extensions.Configuration;
using Utils.Helpers;

var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, true);

IConfigurationRoot config = builder.Build();

var path = args.Length >= 1
    ? args.First()
    : config["Input:DefaultPath"] ?? throw new ArgumentException("Default path not found.");

var fileHelper = new FileHelper();

var parser = new InputParser(fileHelper);

int parsedLines = 0;
CrateStack[] stacks = parser.ParseCrateStacks(path, ref parsedLines);

IEnumerable<Instruction> instructions = parser.ParseInstructions(path, parsedLines);

var crane = new Crane();

IEnumerable<Crate> result = crane.DoWork(instructions, stacks);

Console.WriteLine($"The crates on top of each stack are: '{string.Join("", result.Select(crate => crate.Value))}'");

Console.ReadKey();
