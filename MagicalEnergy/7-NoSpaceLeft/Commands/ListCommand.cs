using _7_NoSpaceLeft.FileStructure;
using JetBrains.Annotations;

namespace _7_NoSpaceLeft.Commands;

[UsedImplicitly]
internal class ListCommand : Command
{
    public override string Input => "ls";

    public override ICommandParameters Parameters { get; } = new ListCommandParameters();

    public override Node Invoke(Node node)
    {
        var directoryNode = node as DirectoryNode ?? throw new InvalidOperationException("Current node is not a directory.");

        foreach (string parameter in Parameters)
        {
            string[] parsed = parameter.Split(' ');

            string info = parsed[0];
            string name = parsed[1];

            if (info == "dir")
            {
                directoryNode.Nodes.Add(name, new DirectoryNode(name, node));
            }
            else if (int.TryParse(info, out int size))
            {
                directoryNode.Nodes.Add(name, new FileNode(name, size, node));
            }
            else
            {
               throw new ArgumentException($"Unknown parameter for {nameof(ListCommand)} command.");
            }
        }

        return node;
    }
}
