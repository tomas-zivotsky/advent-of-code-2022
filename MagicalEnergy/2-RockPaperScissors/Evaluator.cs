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

    public int Evaluate(Choice choice, Result result)
    {
        var difference = (int)choice - (int)result;

        var response = difference switch
        {
            -3 => Response.Rock,
            -2 => Response.Rock,
            2 => Response.Rock,

            -5 => Response.Paper,
            -1 => Response.Paper,
            3 => Response.Paper,

            -4 => Response.Scissor,
            0 => Response.Scissor,
            1 => Response.Scissor,

            _ => throw new NotImplementedException()
        };

        return (int)result + (int)response;
    }
}
