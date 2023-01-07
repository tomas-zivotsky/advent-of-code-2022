namespace _3_Rucksacks;

internal class ItemListHelper
{
    public IDictionary<Item, int> GetWeightMap(IEnumerable<Item> items)
    {
        var set = new Dictionary<Item, int>();

        foreach (var item in items)
        {
            var originalValue = set.TryGetValue(item, out int value) ? value : 0;
            set[item] = ++originalValue;
        }

        return set;
    }
}
