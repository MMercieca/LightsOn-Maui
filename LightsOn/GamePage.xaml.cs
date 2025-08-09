namespace LightsOn;

using System.Threading.Tasks;
using System.Windows.Input;

public partial class GamePage : ContentPage
{
	private GameBoard Board { get; set; }
	private Grid LightGrid { get; set; }

	public GamePage(int? difficulty)
	{
		InitializeComponent();

    if (difficulty == null || difficulty == 1)
    {
      Board = new GameBoard(5, 9, 1);
    }
    else if (difficulty == 2)
    {
      Board = new GameBoard(5, 15, 1);
    }
    else
    {
      Board = new GameBoard(5, 10, 2);
    }

		AddLights();
		Content = LightGrid;
		ShowBoard();
	}

	private void AddLights()
	{
		LightGrid = new Grid
		{
			RowSpacing = 10,
			ColumnSpacing = 10,
			Margin = new Thickness(10)
		};

		for (int row = 0; row < Board.GridSize; row++)
		{
			LightGrid.RowDefinitions.Add(new RowDefinition());
			LightGrid.ColumnDefinitions.Add(new ColumnDefinition());
		}

		for (int row = 0; row < Board.GridSize; row++)
		{
			for (int col = 0; col < Board.GridSize; col++)
			{
				Button light = new Button
				{
					CommandParameter = $"{row},{col}",
				};

				light.Clicked += OnLightClicked;

				LightGrid.Add(light, col, row);
			}
		}
	}
	private void OnLightClicked(object? sender, EventArgs e)
	{
		if (sender is null)
		{
			return;
		}

		Button pressed = (Button)sender;
		int row = GetPosFromButton(pressed, 0);
		int col = GetPosFromButton(pressed, 1);

		Board.Toggle(row, col);
		ShowBoard();
	}

	private void ResetBoardClicked(object? sender, EventArgs e)
	{
		Board.Reset();
		ShowBoard();
	}

	private async Task ShowBoard()
	{
		foreach (var child in LightGrid)
		{
			int row = LightGrid.GetRow(child);
			int col = LightGrid.GetColumn(child);
			Button light = (Button)child;
			if (Board.Board[row, col] == 0)
			{
				light.BackgroundColor = (Color)App.Current.Resources["Level0"];
			}
			else if (Board.Board[row, col] == 1)
			{
				light.BackgroundColor = (Color)App.Current.Resources["Level1"];
			}
			else
			{
				light.BackgroundColor = (Color)App.Current.Resources["Level2"];
			}
		}

		if (Board.Won())
		{
			await DisplayAlert("Congratulations!", "You won", "OK");
			Navigation.PopAsync();
		}
	}

	private int GetPosFromButton(Button b, int index)
	{
		string s = b.CommandParameter.ToString();
		string[] parts = s.Split(",");
		return int.Parse(parts[index]);
	}
}
