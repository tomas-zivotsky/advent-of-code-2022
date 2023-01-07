using Microsoft.Extensions.Configuration;
using Utils.Helpers;

namespace _3_Rucksacks;

internal class InputParser
{
    private readonly FileHelper _fileHelper;
    private readonly IConfigurationRoot _configuration;
    private readonly ItemListHelper _itemListHelper;

    public InputParser(FileHelper fileHelper, IConfigurationRoot configuration, ItemListHelper itemListHelper)
    {
        _fileHelper = fileHelper ?? throw new ArgumentNullException(nameof(fileHelper));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _itemListHelper = itemListHelper ?? throw new ArgumentNullException(nameof(itemListHelper));
    }

    public IEnumerable<Rucksack> Parse(string path)
    {
        _fileHelper.ValidatePath(path);

        foreach (var line in File.ReadLines(path))
        {
            var rucksack = ParseRucksack(line);

            yield return rucksack;
        }
    }

    public IEnumerable<ElfGroup> ParseGroups(string path)
    {
        _fileHelper.ValidatePath(path);
        var groupSize = uint.Parse(_configuration["ElvesInGroupCount"] ?? throw new ArgumentException("Top count not found."));

        foreach (string[]lines in _fileHelper.ReadLines(path, groupSize))
        {
            yield return new(lines.Select(ParseRucksack).ToArray(), _itemListHelper);
        }
    }

    private static Rucksack ParseRucksack(string line)
    {
        string part1 = line.Substring(0, line.Length / 2);
        string part2 = line.Substring(line.Length / 2, line.Length / 2);

        var rucksack = new Rucksack(
            new LargeCompartment(part1.Select(ch => new Item(ch)).ToArray()),
            new LargeCompartment(part2.Select(ch => new Item(ch)).ToArray()));
        return rucksack;
    }
}
