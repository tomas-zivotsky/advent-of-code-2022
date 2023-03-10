using System.Collections;
using _4_CampCleanup;
using Microsoft.Extensions.Configuration;
using Utils.Helpers;

var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, true);

IConfigurationRoot config = builder.Build();

var path = args.Length >= 1
    ? args.First()
    : config["Input:DefaultPath"] ?? throw new ArgumentException("Default path not found.");

var fileHelper = new FileHelper();

var parser = new InputParser(fileHelper, config);

IEnumerable<AssignmentPair> pairs = parser.Parse(path).ToArray();

int coveredCount = 0;
int overlappingCount = 0;
foreach (AssignmentPair pair in pairs)
{
    var result = (BitArray) pair.AssignedCamps1.Clone();

    result.And(pair.AssignedCamps2);

    bool overlapped = result.OfType<bool>().Any(value => value);
    if (overlapped) overlappingCount++;

    bool covered = overlapped && (result.AreEqual(pair.AssignedCamps1) || result.AreEqual(pair.AssignedCamps2));
    if (covered) coveredCount++;
}

Console.WriteLine($"Number of pairs that does one range fully contain the other is: {coveredCount}.");
Console.WriteLine($"Number of pairs that do the range overlap is: {overlappingCount}.");

Console.ReadKey();
