namespace Utils.Helpers;

public class FileHelper
{
    public void ValidatePath(string path)
    {
        if (path is null) throw new ArgumentNullException(nameof(path));
        if (!File.Exists(path)) throw new ArgumentException($"File {path} not found.");
    }
}
