using System.Collections;
using Microsoft.Extensions.Configuration;
using Utils.Helpers;

namespace _4_CampCleanup;

public class InputParser
{
    private readonly FileHelper _fileHelper;
    private readonly int _maxId;

    public InputParser(FileHelper fileHelper, IConfiguration configuration)
    {
        _fileHelper = fileHelper ?? throw new ArgumentNullException(nameof(fileHelper));
        var configuration1 = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _maxId = int.Parse(configuration1["MaxCampId"] ?? throw new ArgumentException("Max camp id not found."));
    }

    public IEnumerable<AssignmentPair> Parse(string path)
    {
        _fileHelper.ValidatePath(path);


        foreach (var line in File.ReadLines(path))
        {
            string[] sections = line.Split(',');

            BitArray range1 = GetMask(sections[0]);
            BitArray range2 = GetMask(sections[1]);

            yield return new(range1, range2);
        }
    }

    private BitArray GetMask(string section)
    {
        string[] parts = section.Split('-');
        int from = int.Parse(parts[0]);
        int to = int.Parse(parts[1]);

        var mask = new BitArray(_maxId, false);

        for (int index = from - 1; index < to; index++)
        {
            mask[index] = true;
        }

        return mask;
    }
}
