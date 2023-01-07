using System.Collections;

namespace _4_CampCleanup;

public static class BitArrayExtensions
{
    public static bool AreEqual(this BitArray source, BitArray target)
    {
        var result = (BitArray) source.Clone();
        return result.Xor(target).OfType<bool>().All(value => !value);
    }
}
