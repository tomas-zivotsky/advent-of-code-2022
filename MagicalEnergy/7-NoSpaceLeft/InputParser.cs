using _7_NoSpaceLeft.Commands;
using _7_NoSpaceLeft.FileStructure;
using Utils.Helpers;

namespace _7_NoSpaceLeft;

internal class InputParser
{
    private readonly FileHelper _fileHelper;
    private readonly CommandFactory _commandFactory;

    public InputParser(FileHelper fileHelper, CommandFactory commandFactory)
    {
        _fileHelper = fileHelper ?? throw new ArgumentNullException(nameof(fileHelper));
        _commandFactory = commandFactory ?? throw new ArgumentNullException(nameof(commandFactory));
    }

    internal RootNode Parse(string path)
    {
        _fileHelper.ValidatePath(path);

        var structure = new RootNode();

        using var reader = new StreamReader(path);
        ICommand? command = null;
        Node currentNode = structure;
        var inputs = new List<string>();

        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine()!;

            if (line.StartsWith('$'))
            {
                if (command is not null)
                {
                    inputs.ForEach(input => command.Parameters.Add(input));
                    currentNode = command.Invoke(currentNode);
                }
                inputs.Clear();
                command = ParseCommand(line);
            }
            else
            {
                inputs.Add(line);
            }
        }

        // invoke last command
        inputs.ForEach(input => command?.Parameters.Add(input));
        command?.Invoke(currentNode);

        return structure;
    }

    private ICommand ParseCommand(string line)
    {
        ICommand? command = _commandFactory.CreateCommand(line);
        return command ?? throw new ArgumentException($"Command not created: {line}.");
    }
}
