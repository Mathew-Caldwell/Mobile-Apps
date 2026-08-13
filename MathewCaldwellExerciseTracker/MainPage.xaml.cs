namespace MathewCaldwellExerciseTracker
{
    
    
    public partial class MainPage : ContentPage
    {
        ExerciseData exersiceData = new ExerciseData();

        public MainPage()
        {
            InitializeComponent();
            exersiceData.load();
            UpdateAll();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            exersiceData.save();
        }

        private void Setting_Clicked(object sender, EventArgs e)
        {
            SettingsPage settingsPage = new SettingsPage();
            Navigation.PushModalAsync(settingsPage);
        }

        private void Log_Clicked(object sender, EventArgs e)
        {
            int minDone = int.Parse(logEntry.Text);
            exersiceData.IncrementMinDone(minDone);
            
            logEntry.Text = string.Empty;
            UpdateAll();
        }

        #region Update Minute Value Counters
        private void UpdateAll()
        {
            UpdateTotalMinutesDoneToday();
            UpdateAverageToCompleteYear();
            UpdateTotalAmountDoneAndTotalShouldHaveDone();
        }
        private void UpdateTotalMinutesDoneToday()
        {
            //updates number of minutes of exercise done today
            MinutesToday.Text = $"{exersiceData.numMinutesToday} minutes done today";
        }

        private void UpdateAverageToCompleteYear()
        {
            //updates how many minutes of exercise user has to do each day for rest of year to hit goal
            NumMinForRestOfYear.Text = $"Need to do {exersiceData.ConvertMinToHours(exersiceData.CalculateAvgMinForRestOfYear())} hours of exercise per day";

        }

        private void UpdateTotalAmountDoneAndTotalShouldHaveDone()
        {
            //updates the total amount of minutes of exersice the user has done then converts into hours
            //updates the total amount of minutes the user should have done then converts into hours

            TotalAndRequiredExercise.Text = $"Total exercise time: {exersiceData.ConvertMinToHours(exersiceData.numMinutesTotal)} hours." +
                $" You should have done: {exersiceData.ConvertMinToHours(exersiceData.CalculateTotalNumOfMinShouldHaveDone())} hours";
        }
        #endregion

    }
}
