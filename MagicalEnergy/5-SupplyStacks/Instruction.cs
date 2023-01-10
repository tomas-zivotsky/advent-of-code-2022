namespace _5_SupplyStacks;

public class Instruction
{
    public Instruction(int count, int from, int to)
    {
        Count = count;
        From = from;
        To = to;
    }

    public int Count { get; }

    public int From { get; }

    public int To { get; }
}
