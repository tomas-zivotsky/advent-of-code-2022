namespace _7_NoSpaceLeft.FileStructure;

internal class FilterBuilder
{
    private readonly RootNode _root;
    private readonly List<Func<Node, bool>> _predicates = new();

    public FilterBuilder(RootNode root)
    {
        _root = root ?? throw new ArgumentNullException(nameof(root));
    }

    public FilterBuilder Directories()
    {
        _predicates.Add(node => node.Type == FileType.Directory);
        return this;
    }

    public FilterBuilder MaxSize(int max)
    {
        _predicates.Add(node => node.Size <= max);
        return this;
    }

    public IEnumerable<Node> Build()
    {
        return ApplyFilter(_root)
            .Where(node => node is not null)
            .Select(node => node!);
    }

    private IEnumerable<Node?> ApplyFilter(Node node)
    {
        switch (node)
        {
            case FileNode file:
                yield return Evaluate(file);
                break;

            case DirectoryNode directory:
                yield return Evaluate(directory);
                foreach (var item in directory.Nodes.SelectMany(child => ApplyFilter(child.Value)))
                {
                    yield return item;
                }
                break;
        }
    }

    private Node? Evaluate(Node item)
    {
        return _predicates.TrueForAll(predicate => predicate.Invoke(item)) ? item : null;
    }
}
