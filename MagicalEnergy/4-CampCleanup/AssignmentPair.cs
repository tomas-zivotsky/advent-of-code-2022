using System.Collections;

namespace _4_CampCleanup;

public class AssignmentPair
{
    public AssignmentPair(BitArray assignedCamps1, BitArray assignedCamps2)
    {
        AssignedCamps1 = assignedCamps1;
        AssignedCamps2 = assignedCamps2;
    }

    public BitArray AssignedCamps1 { get; }

    public BitArray AssignedCamps2 { get; }
}
