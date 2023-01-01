namespace _2_RockPaperScissors;

public class Evaluator
{
    public int Evaluate(Choice choice, Response response)
    {
        var difference = (int)choice - (int)response;

        var result = difference switch
        {
            0 => Result.Draw,
            -2 => Result.Loss,
            1 => Result.Loss,
            -1 => Result.Win,
            2 => Result.Win,
            _ => throw new NotImplementedException()
        };

        return (int)result + (int)response;
    }
}
