using _7_NoSpaceLeft;
using _7_NoSpaceLeft.FileStructure;
using Microsoft.Extensions.Configuration;
using Utils.Helpers;

var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, true);

IConfigurationRoot config = builder.Build();

var path = args.Length >= 1
    ? args.First()
    : config["Input:DefaultPath"] ?? throw new ArgumentException("Default path not found.");

var fileHelper = new FileHelper();

var parser = new InputParser(fileHelper, new());

RootNode fileStructure = parser.Parse(path);

var filterBuilder = new FilterBuilder(fileStructure);

var directories = filterBuilder
    .Directories()
    .MaxSize(100_000)
    .Build();

Console.WriteLine($"Total size of all filtered directories is: {directories.Sum(dir => dir.Size)}.");

Console.ReadKey();
