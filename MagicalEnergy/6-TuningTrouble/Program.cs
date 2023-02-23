using _6_TuningTrouble;
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
IEnumerable<char> signals = parser.Parse(path);

var signalReader = new SignalReader(signals);

int packetOffset = signalReader.FindOffset(4);
Console.WriteLine($"Packet offset of the input buffer is {packetOffset}.");

Console.ReadKey();
