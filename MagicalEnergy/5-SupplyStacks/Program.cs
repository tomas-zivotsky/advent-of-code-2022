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
CrateStack[] stacks9000 = parser.ParseCrateStacks(path, ref parsedLines);
parsedLines = 0;
CrateStack[] stacks9001 = parser.ParseCrateStacks(path, ref parsedLines);

IEnumerable<Instruction> instructions = parser.ParseInstructions(path, parsedLines).ToArray();

var crateMover9000 = new CrateMover9000();
IEnumerable<Crate> result9000 = crateMover9000.DoWork(instructions, stacks9000);
Console.WriteLine($"Using {crateMover9000.Name}: the crates on top of each stack are: '{string.Join("", result9000.Select(crate => crate.Value))}'");

var crateMover9001 = new CrateMover9001();
IEnumerable<Crate> result9001 = crateMover9001.DoWork(instructions, stacks9001);
Console.WriteLine($"Using {crateMover9001.Name}: the crates on top of each stack are: '{string.Join("", result9001.Select(crate => crate.Value))}'");

Console.ReadKey();
