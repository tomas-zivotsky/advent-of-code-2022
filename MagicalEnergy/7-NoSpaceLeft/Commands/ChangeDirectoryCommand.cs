using _7_NoSpaceLeft.FileStructure;
using JetBrains.Annotations;

namespace _7_NoSpaceLeft.Commands;

[UsedImplicitly]
internal class ChangeDirectoryCommand : Command
{
    public override string Input => "cd";

    public override ICommandParameters Parameters { get; } = new ChangeDirectoryCommandParameters();

    public override Node Invoke(Node node)
    {
        var directoryNode = node as DirectoryNode ?? throw new InvalidOperationException($"Command {nameof(ChangeDirectoryCommand)} can be called only over directory node.");

        Parameters.Validate();

        var parameter = Parameters.First();

        if (parameter == "..")
        {
            return directoryNode.Parent ?? node;
        }

        return directoryNode.Nodes.TryGetValue(parameter, out Node? value) ? value : node;
    }
}
