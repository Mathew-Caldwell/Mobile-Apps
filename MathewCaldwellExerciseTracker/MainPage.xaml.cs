using System.Windows;

namespace MathewCaldwellExerciseTracker
{
    
    
    public partial class MainPage : ContentPage
    {
        ExerciseData exersiceData = new ExerciseData();

        #region Initialising/ loading and saving
        public MainPage()
        {
            InitializeComponent();
            exersiceData.load();
            UpdateAll();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            exersiceData.load();
            UpdateAll();
        }
        #endregion

        #region Inputs
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
        #endregion

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

            if(exersiceData.numMinutesToday < exersiceData.numMinutesPerDay)
            {
                MinutesToday.TextColor = Colors.Red;
            }
            else
            {
                MinutesToday.TextColor = Colors.Green;
            }
        }

        private void UpdateAverageToCompleteYear()
        {
            //updates how many minutes of exercise user has to do each day for rest of year to hit goal
            float avgForRest = float.Parse(exersiceData.ConvertMinToHours(exersiceData.CalculateAvgMinForRestOfYear()));
            if(avgForRest < 0)
            {
                avgForRest = 0.0f;
            }
            NumMinForRestOfYear.Text = $"Need to do {avgForRest} hours of exercise per day";

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
