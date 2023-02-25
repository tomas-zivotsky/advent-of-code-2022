namespace _7_NoSpaceLeft.Commands;

internal class ChangeDirectoryCommandParameters : CommandParametersBase
{
    public override int? MaxCount => 1;

    public override int MinCount => 1;
}
