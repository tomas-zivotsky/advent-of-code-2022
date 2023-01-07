using Utils.Helpers;

namespace _2_RockPaperScissors;

internal class InputParser
{
    private readonly FileHelper _fileHelper;

    public InputParser(FileHelper fileHelper)
    {
        _fileHelper = fileHelper ?? throw new ArgumentNullException(nameof(fileHelper));
    }

    public IEnumerable<(TItem1, TItem2)> Parse<TItem1, TItem2>(string path)
    {
        _fileHelper.ValidatePath(path);

        foreach (var line in File.ReadLines(path))
        {
            if (line.Length != 3) throw new ArgumentException($"Invalid input format: '{line}'.");

            ReadOnlySpan<char> choiceInput = line.AsSpan(0, 1);
            ReadOnlySpan<char> responseInput = line.AsSpan(2, 1);

            var item1 = ParseEnumInput<TItem1>(choiceInput);
            var item2 = ParseEnumInput<TItem2>(responseInput);

            yield return (item1, item2);
        }
    }
    
    private static T ParseEnumInput<T>(ReadOnlySpan<char> input)
    {
        Enum.TryParse(typeof(T), input, true, out var result);
        return (T) (result ?? throw new ArgumentException($"Input '{input}' could not be parsed to {typeof(T).Name}."));
    }
}
