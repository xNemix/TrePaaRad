using TrePaaRad;

var board = new Board();
var gameConsole = new GameConsole(board);
string startNewGame = String.Empty;
while (gameConsole._gameIsRunning)
{
    if (board.HasPlayerWon(1))
    {
        Console.WriteLine("X vant spillet");
        gameConsole._gameIsRunning = false;
        Console.WriteLine("Vil du starte et nytt spill ?");
        startNewGame = Console.ReadLine();
        if (startNewGame.ToLower() == "ja")
        {
            board.RestartGame();
        }
    }
    if (board.HasPlayerWon(2))
    {
        Console.WriteLine("O vant spillet");
        gameConsole._gameIsRunning = false;
        Console.WriteLine("Vil du starte et nytt spill ?");
        startNewGame = Console.ReadLine();
        if (startNewGame.ToLower() == "ja")
        {
            board.RestartGame();
        }
    }
    gameConsole.Show();
    Console.WriteLine("Skriv inn hvor du vil sette et kryss (f.eks \"a2\")");
    var pos = Console.ReadLine()!;
    var hasPlayerPlacedMarker = board.Mark(pos);
    
    if (hasPlayerPlacedMarker)
    {
        gameConsole.Show();
        Thread.Sleep(2000);
        board.MarkRandom(false);
        board.HasPlayerWon(2);
    }
    else
    {
        Console.WriteLine("Du kan kun plassere dine brikker på en tom plass!");
        gameConsole.Show();
    }
}




