namespace _7_NoSpaceLeft.FileStructure;

internal class FileNode : Node
{
    public FileNode(string name, int size, Node parent) : base(name, parent)
    {
        Size = size;
    }

    public override FileType Type => FileType.File;

    public override int Size { get; }
}
