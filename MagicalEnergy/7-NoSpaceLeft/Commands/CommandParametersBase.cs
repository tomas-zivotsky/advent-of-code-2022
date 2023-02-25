namespace _7_NoSpaceLeft.Commands;

internal abstract class CommandParametersBase: List<string>, ICommandParameters
{
    public virtual bool IsMultiline => false;

    public virtual int? MaxCount => null;

    public virtual int MinCount => 0;

    public void Validate()
    {
        Guards.Guard.ArgumentIsGreaterOrEqual(() => Count, MinCount);
        if (MaxCount.HasValue)
        {
            Guards.Guard.ArgumentIsLowerOrEqual(() => Count, MaxCount.Value);
        }
    }

    public new void Add(string item)
    {
        if (MaxCount.HasValue && Count >= MaxCount) throw new ArgumentException($"Command of type {GetType().Name} cannot have more than {MaxCount} parameter(s).");

        base.Add(item);
    }
}
