namespace _3_Rucksacks;

internal class ElfGroup
{
    private readonly ItemListHelper _itemListHelper;

    public ElfGroup(Rucksack[] rucksacks, ItemListHelper itemListHelper)
    {
        Rucksacks = rucksacks;
        _itemListHelper = itemListHelper;
    }

    public Rucksack[] Rucksacks { get; }

    public Item? FindCommon()
    {
        var items = Rucksacks
            .SelectMany(
                rucksack => rucksack.Compartments.SelectMany(
                    compartment => compartment.Items.Distinct())
                    .Distinct());

        IDictionary<Item, int> weightedMap = _itemListHelper.GetWeightMap(items);

        return weightedMap.Any() ? weightedMap.First(item => item.Value == Rucksacks.Length).Key : null;
    }
}
