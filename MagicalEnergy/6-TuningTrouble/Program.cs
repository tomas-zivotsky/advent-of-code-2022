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

var parser = new InputParser(fileHelper);
IEnumerable<char> signals = parser.Parse(path);

var signalReader = new SignalReader(signals);

int packetSequenceLength = int.Parse(config["PacketSequenceLength"] ?? throw new ArgumentException("Packet sequence length not found."));
int packetOffset = signalReader.FindOffset(packetSequenceLength);
Console.WriteLine($"Packet offset of the input buffer is {packetOffset}.");

int messageSequenceLength = int.Parse(config["MessageSequenceLength"] ?? throw new ArgumentException("Message sequence length not found."));
int messageOffset = signalReader.FindOffset(messageSequenceLength);
Console.WriteLine($"Message offset of the input buffer is {messageOffset}.");

Console.ReadKey();
