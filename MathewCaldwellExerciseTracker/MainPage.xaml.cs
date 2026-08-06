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
            //load();
            UpdateAll();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //save();
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

        #region Update Minute Value Counters
        private void UpdateAll()
        {
            UpdateTotalMinutesDoneToday();
            UpdateAverageToCompleteYear();
            UpdateTotalAmountDone();
            UpdateTotalAmountShouldHaveDone();
        }
        private void UpdateTotalMinutesDoneToday()
        {
            //updates number of minutes of exercise done today
        }

        private void UpdateAverageToCompleteYear()
        {
            //updates how many minutes of exercise user has to do each day for rest of year to hit goal
        }

        private void UpdateTotalAmountDone()
        {
            //updates the total amount of minutes of exersice the user has done then converts into hours
        }

        private void UpdateTotalAmountShouldHaveDone()
        {
            //updates the total amount of minutes the user should have done then converts into hours
        }
        #endregion

    }
}
