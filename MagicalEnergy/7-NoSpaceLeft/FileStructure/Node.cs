namespace _7_NoSpaceLeft.FileStructure;

internal abstract class Node
{
    protected Node(string name, Node? parent)
    {
        Name = name;
        Parent = parent;
    }

    public Node? Parent { get; }

    public abstract FileType Type { get; }

    public string Name { get; }

    public abstract int Size { get; }
}
