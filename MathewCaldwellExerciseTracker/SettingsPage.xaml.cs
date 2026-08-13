using Microsoft.Maui.Graphics;
namespace MathewCaldwellExerciseTracker
{
    public partial class SettingsPage : ContentPage
    {
        ExerciseData exerciseData = new ExerciseData();
        public SettingsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            exerciseData.load();

            changeMinPerDay.Value = exerciseData.numMinutesPerDay;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            exerciseData.save();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            numberOfMinutesPerDayLabel.Text = ((int)changeMinPerDay.Value).ToString();
            exerciseData.numMinutesPerDay = (int)changeMinPerDay.Value;
        }

        private void RestedData_Clicked(object sender, EventArgs e)
        {
            exerciseData.ResetData();
            exerciseData.save();
            exerciseData.load();
            changeMinPerDay.Value = exerciseData.numMinutesPerDay;
        }

        void ChangeBackgroundColour(string backgroundColour)
        {
            
        }

        void ChangeTextColour(string textColour)
        {

        }
    }
}