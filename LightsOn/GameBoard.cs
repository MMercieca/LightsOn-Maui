public class GameBoard
{
  private const int DefaultStartingMoves = 10;
  private const int DefaultSwitchMax = 2;

  public int GridSize { get; private set; }
  public int SwitchMax { get; private set; }
  public int StartingMoves { get; private set; }
  public int[,] Board { get; private set; }
  private int[,] OriginalBoard { get; set; }

  public GameBoard(int GridSize, int? StartingMoves, int? SwitchMax)
  {
    this.GridSize = GridSize;
    Board = new int[GridSize, GridSize];
    OriginalBoard = new int[GridSize, GridSize];

    if (StartingMoves is not null)
    {
      this.StartingMoves = (int)StartingMoves;
    }
    else
    {
      this.StartingMoves = DefaultStartingMoves;
    }

    if (SwitchMax is not null)
    {
      this.SwitchMax = (int)SwitchMax;
    }
    else
    {
      this.SwitchMax = DefaultSwitchMax;
    }

    SetupGameBoard();
    RandomizeGameBoard();
  }

  private void DebugBoard()
  {
    for (int row = 0; row < GridSize; row++)
    {
      string line = "";
      for (int col = 0; col < GridSize; col++)
      {
        line = $"{line} {Board[row, col]}";
      }
      System.Diagnostics.Debug.WriteLine(line);
    }
  }

  public void SetupGameBoard()
  {
    for (int X = 0; X < GridSize; X++)
    {
      for (int Y = 0; Y < GridSize; Y++)
      {
        Board[X, Y] = SwitchMax;
      }
    }
  }

  public void RandomizeGameBoard()
  {
    System.Diagnostics.Debug.WriteLine("--------------- New Game ----------------");
    Random rand = new Random();
    for (int i = 0; i < StartingMoves; i++)
    {
      int row = rand.Next(GridSize);
      int col = rand.Next(GridSize);
      Toggle(row, col);
      System.Diagnostics.Debug.WriteLine($"{row},{col}");
    }
    CopyBoard(Board, OriginalBoard);
  }

  private void CopyBoard(int[,] source, int [,] destination)
  {
    for (int row = 0; row < GridSize; row++)
    {
      for (int col = 0; col < GridSize; col++)
      {
        destination[row, col] = source[row, col];
      }
    }
  }

  public void Reset()
  {
    CopyBoard(OriginalBoard, Board);
  }

  private void ToggleAt(int row, int col)
  {
    if (row < 0 || col < 0 || row >= GridSize || col >= GridSize)
    {
      return;
    }

    Board[row, col]++;
    if (Board[row, col] > SwitchMax)
    {
      Board[row, col] = 0;
    }
  }

  public void Toggle(int row, int col)
  {
    ToggleAt(row, col);
    ToggleAt(row - 1, col);
    ToggleAt(row + 1, col);
    ToggleAt(row, col - 1);
    ToggleAt(row, col + 1);
  }

  public bool Won()
  {
    bool won = true;

    for (int row = 0; row < GridSize; row++)
    {
      for (int col = 0; col < GridSize; col++)
      {
        won = won && (Board[row, col] == SwitchMax);
      }
    }

    return won;
  }
}