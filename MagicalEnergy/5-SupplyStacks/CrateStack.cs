namespace _5_SupplyStacks;

internal class CrateStack : LinkedList<Crate>
{
    public IEnumerable<Crate> PopFirst(int count = 1)
    {
        var result = this.Take(count).ToList();

        for (int i = 0; i < count; i++)
        {
            RemoveFirst();
        }

        return result;
    }

    public void AddFirst(IEnumerable<Crate> items)
    {
        foreach (var item in items)
        {
            AddFirst(item);
        }
    }
}
