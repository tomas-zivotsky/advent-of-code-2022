using Utils.Extensions;
using Utils.Helpers;

namespace _1_CalorieCounting;

public class InputParser
{
    private readonly FileHelper _fileHelper;

    public InputParser(FileHelper fileHelper)
    {
        _fileHelper = fileHelper;
    }

    public IEnumerable<Inventory> Parse(string path)
    {
        _fileHelper.ValidatePath(path);

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
