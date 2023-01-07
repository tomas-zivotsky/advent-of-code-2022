namespace Utils.Helpers;

public class FileHelper
{
    public void ValidatePath(string path)
    {
        if (path is null) throw new ArgumentNullException(nameof(path));
        if (!File.Exists(path)) throw new ArgumentException($"File {path} not found.");
    }

    public IEnumerable<string[]> ReadLines(string path, uint count)
    {
        var buffer = new string[count];
        uint index = 0;

        foreach (string line in File.ReadLines(path))
        {
            buffer[index] = line;
            index = (index + 1) % (count);

            if (index != 0) continue;

            var group = new string[count];
            buffer.CopyTo(group, 0);

            yield return group;
        }
    }
}
