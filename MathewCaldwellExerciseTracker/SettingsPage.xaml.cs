namespace MathewCaldwellExerciseTracker
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //load();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //save();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            numberOfMinutesPerDayLabel.Text = ((int)changeMinPerDay.Value).ToString();
        }
    }
}