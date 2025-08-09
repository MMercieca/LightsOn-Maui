namespace LightsOn;
using System.Windows.Input;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	public async void OnNewGameClicked(object sender, EventArgs e)
	{
		Button s = (Button)sender;
		int difficulty = int.Parse(s.CommandParameter.ToString());
		await Navigation.PushAsync(new GamePage(difficulty));
	}
}
