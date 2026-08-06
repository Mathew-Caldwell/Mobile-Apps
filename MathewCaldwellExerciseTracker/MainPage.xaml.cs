namespace MathewCaldwellExerciseTracker
{
    //Data layer needs:
    //   Save/load - num min today, num min total, text/background colour, num min required/day (5-60)
    //   calculate avg num min need to do for rest of year
    //   calculate total num min should have done
    //   convert min - hours
    //   calculate avg min/day done
    //   increment num on min done 
    //   check if new year
    //   reset data
    
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Setting_Clicked(object sender, EventArgs e)
        {
            SettingsPage settingsPage = new SettingsPage();
            Navigation.PushModalAsync(settingsPage);
        }

        private void Log_Clicked(object sender, EventArgs e)
        {
            logEntry.Text = string.Empty;
        }
    }
}
