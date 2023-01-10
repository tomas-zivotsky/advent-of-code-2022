using System.Text.RegularExpressions;
using Utils.Extensions;
using Utils.Helpers;

namespace _5_SupplyStacks;

internal class InputParser
{
    private readonly FileHelper _fileHelper;
    private readonly Regex _crateRegex;
    private readonly Regex _instructionRegex;

    public InputParser(FileHelper fileHelper)
    {
        _fileHelper = fileHelper ?? throw new ArgumentNullException(nameof(fileHelper));
        _crateRegex = new(@"\[\w\]");
        _instructionRegex = new(@"^move (\d+) from (\d+) to (\d+)$");
    }

    internal CrateStack[] ParseCrateStacks(string path, ref int parsedLines)
    {
        _fileHelper.ValidatePath(path);

        var crateStacks = new Dictionary<int, CrateStack>();

        foreach (var line in File.ReadLines(path).Skip(parsedLines))
        {
            parsedLines++;

            if (line.IsNullOrWhiteSpace()) break;

            Match match = _crateRegex.Match(line);
            while (match.Success)
            {
                var crate = new Crate(match.ValueSpan);

                const int groupSize = 3;
                const int identSize = 1;
                int stackIndex = match.Index / (groupSize + identSize);

                CrateStack stack = crateStacks.TryGetValue(stackIndex, out var value) ? value : new();
                stack.AddLast(crate);

                crateStacks[stackIndex] = stack;

                match = match.NextMatch();
            }
        }

        return crateStacks
            .OrderBy(stack => stack.Key)
            .Select(stack => stack.Value)
            .ToArray();
    }

    public IEnumerable<Instruction> ParseInstructions(string path, int parsedLines)
    {
        _fileHelper.ValidatePath(path);

        foreach (var line in File.ReadLines(path).Skip(parsedLines))
        {
            Match match = _instructionRegex.Match(line);

            int[] values = match.Groups.Values.Skip(1).Select(group => int.Parse(group.Value)).ToArray();

            yield return new(values[0], values[1], values[2]);
        }
    }
}
