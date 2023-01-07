using Utils.Extensions;

namespace _3_Rucksacks;

internal record Item(char Type)
{
    public int Priority
    {
        get
        {
            int value = Type;

            if (value.IsBetween('a', 'z'))
            {
                value -= 'a';
                value += 1;
            }
            else if (value.IsBetween('A', 'Z'))
            {
                value -= 'A';
                value += 27;
            }
            else
            {
                throw new ArgumentException($"{nameof(Type)} {Type} is ouf of defined range.");
            }

            return value;
        }
    }
}
