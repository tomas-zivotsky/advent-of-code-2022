namespace _7_NoSpaceLeft.Commands;

internal interface ICommandParameters : IList<string>
{
    bool IsMultiline { get; }

    int? MaxCount { get; }

    int MinCount { get; }

    void Validate();
}
