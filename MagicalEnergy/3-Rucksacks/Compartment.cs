namespace _3_Rucksacks;

internal abstract class Compartment
{
    protected Compartment(Item[] items) => Items = items ?? throw new ArgumentNullException(nameof(items));

    public Item[] Items { get; }

    public int Capacity => Items.Length;
}
