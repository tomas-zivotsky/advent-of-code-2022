namespace _5_SupplyStacks;

internal abstract class Crane
{
    public virtual string Name => "Just a crane";

    protected abstract bool IsAbleToPickMore { get; }

    public IEnumerable<Crate> DoWork(IEnumerable<Instruction> instructions, CrateStack[] stacks)
    {
        foreach (var instruction in instructions)
        {
            var taken = stacks[instruction.From - 1].PopFirst(instruction.Count);
            stacks[instruction.To - 1].AddFirst(taken, IsAbleToPickMore);
        }

        foreach (var stack in stacks)
        {
            Crate? crate = stack.First?.Value;

            if (crate is null) continue;

            yield return crate;
        }
    }
}
