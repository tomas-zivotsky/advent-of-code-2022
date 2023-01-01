using Utils.Extensions;

namespace _1_CalorieCounting;

public class InputParser
{
    public IEnumerable<Inventory> Parse(string path)
    {
        if (path is null) throw new ArgumentNullException(nameof(path));
        if (!File.Exists(path)) throw new ArgumentException($"File {path} not found.");

        Inventory? current = null;

        foreach (var line in File.ReadLines(path))
        {
            if (line.IsNullOrWhiteSpace())
            {
                if (current is not null)
                {
                    yield return current;
                }

                current = new();
                continue;
            }

            current ??= new();

            if (!int.TryParse(line, out var calories))
                throw new ArgumentException($"Invalid input format: '{line}' is not an integer.");

            current.Food.Add(new(calories));
        }
    }
}
