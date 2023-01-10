namespace _5_SupplyStacks;

public class Crate
{
    public Crate(ReadOnlySpan<char> group)
    {
        Value = group[1];
    }

    public char Value { get; }
}
