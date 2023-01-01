namespace _2_RockPaperScissors;

public class InputParser
{
    public IEnumerable<(Choice,Response)> Parse(string path)
    {
        if (path is null) throw new ArgumentNullException(nameof(path));
        if (!File.Exists(path)) throw new ArgumentException($"File {path} not found.");

        foreach (var line in File.ReadLines(path))
        {
            if (line.Length != 3) throw new ArgumentException($"Invalid input format: '{line}'.");

            ReadOnlySpan<char> choiceInput = line.AsSpan(0, 1);
            ReadOnlySpan<char> responseInput = line.AsSpan(2, 1);

            var choice = ParseEnumInput<Choice>(choiceInput);
            var response = ParseEnumInput<Response>(responseInput);

            yield return (choice, response);
        }
    }

    private static T ParseEnumInput<T>(ReadOnlySpan<char> input)
    {
        Enum.TryParse(typeof(T), input, true, out var result);
        return (T) (result ?? throw new ArgumentException($"Input '{input}' could not be parsed to {typeof(T).Name}."));
    }
}
