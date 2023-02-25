using _7_NoSpaceLeft.FileStructure;

namespace _7_NoSpaceLeft.Commands;

internal interface ICommand
{
    string Input { get; }

    Node Invoke(Node node);

    ICommandParameters Parameters { get; }
}
