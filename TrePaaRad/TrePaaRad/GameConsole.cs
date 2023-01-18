namespace TrePaaRad;

internal class GameConsole
{
    private readonly Board _board;
    public bool _gameIsRunning = true;

    public GameConsole(Board board)
    {
        _board = board;
    }

    public void Show()
    {
        // GameBoard();
         Console.WriteLine(@$"  a b c
 ┌─────┐
1│{GetChar(0)} {GetChar(1)} {GetChar(2)}│
2│{GetChar(3)} {GetChar(4)} {GetChar(5)}│
3│{GetChar(6)} {GetChar(7)} {GetChar(8)}│
 └─────┘");
    }

    private string GetChar(int i)
    {
        var square = _board.Squares[i];
        
        return square.IsEmpty() ? " " :
            square.IsPlayer1() ? "x" : "o";
    }


 //    private void GameBoard()
 //    {
 //        Console.WriteLine(@"  a b c
 // ┌─────┐");
 //        Console.Write("1│");
 //        Console.Write($"{GetChar(0)} {GetChar(1)} {GetChar(2)}");
 //        Console.WriteLine("│");
 //        Console.Write("2│");
 //        Console.Write($"{GetChar(3)} {GetChar(4)} {GetChar(5)}");
 //        Console.WriteLine("│");
 //        Console.Write("3│");
 //        Console.Write($"{GetChar(6)} {GetChar(7)} {GetChar(8)}");
 //        Console.WriteLine("│");
 //        Console.WriteLine(" └─────┘");
 //    }
}

  