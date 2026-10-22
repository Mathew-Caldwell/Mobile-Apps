namespace Mathew_Caldwell_Media_Tracker;

public partial class EverythingTab : ContentPage
{
    TabMangment tab = new TabMangment();
    public EverythingTab()
	{
		InitializeComponent();
		tab.InitialiseDatabase();
		tab.load();
		Temp();
	}

	public void Temp()
	{
		tab.AddMedia("Dune part 3", MediaTypes.Movie, new DateOnly(2026, 12, 16), "null", "null");
	}
}