using _3_Rucksacks;
using Microsoft.Extensions.Configuration;
using Utils.Helpers;

var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, true);

IConfigurationRoot config = builder.Build();

var path = args.Length >= 1
    ? args.First()
    : config["Input:DefaultPath"] ?? throw new ArgumentException("Default path not found.");

var fileHelper = new FileHelper();

var parser = new InputParser(fileHelper, config, new());
IEnumerable<Rucksack> inventories = parser.Parse(path);

IEnumerable<Item> odds = inventories.SelectMany(inventory => inventory.FindOdds().Distinct());

int oddsSum = odds.Sum(odd => odd.Priority);

Console.WriteLine($"Sum of all odds is: {oddsSum}.");

IEnumerable<ElfGroup> groups = parser.ParseGroups(path);

int groupsSum = groups.Sum(group => group.FindCommon()?.Priority ?? 0);

Console.WriteLine($"Sum of all elf groups is: {groupsSum}.");

Console.ReadKey();
