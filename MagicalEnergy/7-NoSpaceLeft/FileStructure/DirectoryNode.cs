namespace _7_NoSpaceLeft.FileStructure;

internal class DirectoryNode : Node
{
    public DirectoryNode(string name, Node parent) : base(name, parent)
    {
    }

    public override FileType Type => FileType.Directory;

    public override int Size => Nodes.Values.Sum(node => node.Size);

    public readonly IDictionary<string, Node> Nodes = new Dictionary<string, Node>();

}
