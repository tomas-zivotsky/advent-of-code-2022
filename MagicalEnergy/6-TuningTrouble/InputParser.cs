using Utils.Helpers;

namespace _6_TuningTrouble;

public class InputParser
{
    private readonly FileHelper _fileHelper;

    public InputParser(FileHelper fileHelper)
    {
        _fileHelper = fileHelper ?? throw new ArgumentNullException(nameof(fileHelper));
    }

    public IEnumerable<char> Parse(string path)
    {
        _fileHelper.ValidatePath(path);

        using var reader = new StreamReader(path);

        while (!reader.EndOfStream)
        {
            yield return (char)reader.Read();
        }
    }
}
