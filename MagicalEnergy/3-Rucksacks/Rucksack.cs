namespace _3_Rucksacks;

internal class Rucksack
{
    private readonly ItemListHelper _itemListHelper;

    public Rucksack(params Compartment[] compartments)
    {
        _itemListHelper = new ItemListHelper();
        Compartments = compartments;
    }

    public Compartment[] Compartments { get; }

    public IEnumerable<Item> FindOdds()
    {
        IEnumerable<Item> items = Compartments.SelectMany(compartment => compartment.Items.Distinct());

        IDictionary<Item, int> weightedMap = _itemListHelper.GetWeightMap(items);

        return weightedMap
            .Where(item => item.Value > 1)
            .Select(item => item.Key);
    }
}
