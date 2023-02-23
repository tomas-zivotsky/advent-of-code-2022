using Utils.Collections;

namespace _6_TuningTrouble;

internal class SignalReader
{
    private readonly IEnumerable<char> _signals;

    public SignalReader(IEnumerable<char> signals)
    {
        _signals = signals ?? throw new ArgumentNullException(nameof(signals));
    }


    public int FindOffset(int sequenceLength)
    {
        var queue = new LimitedQueue<char>(sequenceLength);

        int index = 0;
        foreach (char signal in _signals)
        {
            queue.Enqueue(signal);
            index++;

            if (queue.Count < queue.Limit) continue;

            if (queue.Distinct().Count() == queue.Limit) return index;
        }

        return index;
    }
}
