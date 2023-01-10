namespace _5_SupplyStacks;

internal class Crane
{
    public IEnumerable<Crate> DoWork(IEnumerable<Instruction> instructions, CrateStack[] stacks)
    {
        foreach (var instruction in instructions)
        {
            var taken = stacks[instruction.From - 1].PopFirst(instruction.Count);
            stacks[instruction.To - 1].AddFirst(taken);
        }

        foreach (var stack in stacks)
        {
            Crate? crate = stack.First?.Value;

            if (crate is null) continue;

            yield return crate;
        }
    }
}
