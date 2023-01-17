using TrePaaRad;

var board = new Board();
var gameConsole = new GameConsole(board);

var isValidMark = true;
while (gameConsole._gameIsRunning)
{
    
    if (board.HasPlayerWon(1) || board.HasPlayerWon(2))
    {
        Console.Clear();
        gameConsole.Show();
        gameConsole._gameIsRunning = false;
        Console.ForegroundColor = ConsoleColor.Yellow;
        var gameWinner = board.HasPlayerWon(1) ? "Du" : "CPU-en";
        Console.WriteLine($@"
{gameWinner} vant spillet!
Vil du starte et nytt spill ?");
        Console.ForegroundColor = ConsoleColor.White;
        var startNewGame = Console.ReadLine()!.ToLower();
        if (startNewGame == "ja")
        {
            Console.Clear();
            board.RestartGame();
            isValidMark = true;
        }
    }

    if (isValidMark)
    {
        gameConsole.Show();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Skriv inn hvor du vil sette et kryss (f.eks \"a2\")");
        Console.ForegroundColor = ConsoleColor.White;
        var pos = Console.ReadLine()!;
        var hasPlayerPlacedMarker = board.Mark(pos);
        var hasPlayerWon = board.HasPlayerWon(1);
        if (hasPlayerPlacedMarker && !hasPlayerWon)
        {
            Thread.Sleep(1000);
            Console.Clear();
            board.MarkRandom(false);
            isValidMark = true;
        }
        else
        {
            isValidMark = false;
        }
    }
    if (!isValidMark)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Du kan kun plassere brikken din på en tom plass!");
        Console.ForegroundColor = ConsoleColor.White;
        isValidMark = true;
    }
}




