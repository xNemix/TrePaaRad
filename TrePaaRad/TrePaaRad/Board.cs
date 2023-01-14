namespace TrePaaRad;

internal class Board
{
    private readonly Random _random;
    public Square[] Squares { get;}

    public Board()
    {
        Squares = new Square[9];
        for (var i = 0; i < Squares.Length; i++)
        {
            Squares[i] = new Square();
        }

        _random = new Random();
    }

    public bool Mark(string pos)
    {
        var colChar = pos[0];
        var rowChar = pos[1];
        var colIndex = colChar - 'a'; 
        var rowIndex = rowChar - '1';
        var index = rowIndex * 3 + colIndex;
        var isEmpty = false;


        if (!Squares[index].IsEmpty()) return isEmpty;
        Squares[index].Mark(true);
        isEmpty = true;
        return isEmpty;
    }
    

    public void MarkRandom(bool isPlayer1)
    {
        var blankSquares = FindBlankSquares();
        var randomBlankPos = _random.Next(0, blankSquares.Count);
        var randomIndex = blankSquares[randomBlankPos];
        Squares[randomIndex].Mark(isPlayer1);
    }

    private List<int> FindBlankSquares()
    {
        var blankSquares = new List<int>();
        for (var i = 0; i < Squares.Length; i++)
        {
            if (Squares[i].IsEmpty())
            {
                blankSquares.Add(i);
            }
        }
        return blankSquares;
    }

    public bool HasPlayerWon(int mark)
    {
        //TOP ROW H
        if (Squares[0].GetContentValue() == mark && Squares[1].GetContentValue() == Squares[0].GetContentValue() &&
            Squares[1].GetContentValue() == Squares[2].GetContentValue()) return true;
        //MID ROW H
        if (Squares[3].GetContentValue() == mark && Squares[4].GetContentValue() == Squares[3].GetContentValue() &&
            Squares[4].GetContentValue() == Squares[5].GetContentValue()) return true;
        //BOT ROW H
        if (Squares[6].GetContentValue() == mark && Squares[7].GetContentValue() == Squares[6].GetContentValue() &&
            Squares[7].GetContentValue() == Squares[8].GetContentValue()) return true;
        //LEFT ROW V
        if (Squares[0].GetContentValue() == mark && Squares[3].GetContentValue() == Squares[0].GetContentValue() &&
            Squares[3].GetContentValue() == Squares[6].GetContentValue()) return true;
        //MID ROW V
        if (Squares[1].GetContentValue() == mark && Squares[4].GetContentValue() == Squares[1].GetContentValue() &&
            Squares[4].GetContentValue() == Squares[7].GetContentValue()) return true;
        //RIGHT ROW V
        if (Squares[2].GetContentValue() == mark && Squares[5].GetContentValue() == Squares[2].GetContentValue() &&
            Squares[5].GetContentValue() == Squares[7].GetContentValue()) return true;
        //DIAGONAL TOP
        if (Squares[0].GetContentValue() == mark && Squares[4].GetContentValue() == Squares[0].GetContentValue() &&
            Squares[4].GetContentValue() == Squares[8].GetContentValue()) return true;
        //DIAGONAL BOT
        if (Squares[2].GetContentValue() == mark && Squares[4].GetContentValue() == Squares[2].GetContentValue() &&
            Squares[4].GetContentValue() == Squares[6].GetContentValue()) return true;
        else
        {
            return false;
        }
    }

    public void RestartGame()
    {
        for (var i = 0; i < 9; i++)
        {
            Squares[i].SetContentValue(0);
        }
    }
}