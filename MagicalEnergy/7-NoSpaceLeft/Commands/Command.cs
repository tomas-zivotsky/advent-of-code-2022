using _7_NoSpaceLeft.FileStructure;

namespace _7_NoSpaceLeft.Commands;

internal abstract class Command : ICommand
{
    public abstract Node Invoke(Node node);

    public abstract ICommandParameters Parameters { get; }

    public abstract string Input { get; }
}
