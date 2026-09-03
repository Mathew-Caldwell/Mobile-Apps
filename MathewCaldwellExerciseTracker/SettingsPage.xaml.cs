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
            ChangeBackgroundColour(exerciseData.backgroundColour);
            ChangeTextColour(exerciseData.textColour);
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

        private void BackgroundColourChange_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string backgroundColour = button.StyleId;
            ChangeBackgroundColour(backgroundColour);
            exerciseData.backgroundColour = backgroundColour;
        }

        private void ChangeTextColour_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string textColour = button.StyleId;
            ChangeTextColour(textColour);
            exerciseData.textColour = textColour;
        }

        private void RestedData_Clicked(object sender, EventArgs e)
        {
            exerciseData.ResetData();
            exerciseData.save();
            exerciseData.load();
            changeMinPerDay.Value = exerciseData.numMinutesPerDay;
            ChangeBackgroundColour(exerciseData.backgroundColour);
            ChangeTextColour(exerciseData.textColour);
        }

        void ChangeBackgroundColour(string backgroundColour)
        {
            if(backgroundColour == "WhiteBG")
            {
                BackgroundColor = Colors.White;
            }
            else if (backgroundColour == "BlackBG")
            {
                BackgroundColor = Colors.Black;
            }
            else if(backgroundColour == "RedBG")
            {
                BackgroundColor = Colors.Red;
            }
            else if(backgroundColour == "PurpleBG")
            {
                BackgroundColor = Colors.Purple;
            }
        }

        void ChangeTextColour(string textColour)
        {
            if (textColour == "WhiteTC")
            {
                BackButton.TextColor = Colors.White;
                numberOfMinutesPerDayLabel.TextColor = Colors.White;
                backgroundColourLabel.TextColor = Colors.White;
                WhiteBG.TextColor = Colors.White;
                BlackBG.TextColor = Colors.White;
                RedBG.TextColor = Colors.White;
                PurpleBG.TextColor = Colors.White;
                textColourLabel.TextColor = Colors.White;
                WhiteTC.TextColor = Colors.White;
                BlackTC.TextColor = Colors.White;
                RedTC.TextColor = Colors.White;
                PurpleTC.TextColor = Colors.White;
            }
            else if (textColour == "BlackTC")
            {
                BackButton.TextColor = Colors.Black;
                numberOfMinutesPerDayLabel.TextColor = Colors.Black;
                backgroundColourLabel.TextColor = Colors.Black;
                WhiteBG.TextColor = Colors.Black;
                BlackBG.TextColor = Colors.Black;
                RedBG.TextColor = Colors.Black;
                PurpleBG.TextColor = Colors.Black;
                textColourLabel.TextColor = Colors.Black;
                WhiteTC.TextColor = Colors.Black;
                BlackTC.TextColor = Colors.Black;
                RedTC.TextColor = Colors.Black;
                PurpleTC.TextColor = Colors.Black;
            }
            else if (textColour == "RedTC")
            {
                BackButton.TextColor = Colors.Red;
                numberOfMinutesPerDayLabel.TextColor = Colors.Red;
                backgroundColourLabel.TextColor = Colors.Red;
                WhiteBG.TextColor = Colors.Red;
                BlackBG.TextColor = Colors.Red;
                RedBG.TextColor = Colors.Red;
                PurpleBG.TextColor = Colors.Red;
                textColourLabel.TextColor = Colors.Red;
                WhiteTC.TextColor = Colors.Red;
                BlackTC.TextColor = Colors.Red;
                RedTC.TextColor = Colors.Red;
                PurpleTC.TextColor = Colors.Red;
            }
            else if (textColour == "PurpleTC")
            {
                BackButton.TextColor = Colors.Purple;
                numberOfMinutesPerDayLabel.TextColor = Colors.Purple;
                backgroundColourLabel.TextColor = Colors.Purple;
                WhiteBG.TextColor = Colors.Purple;
                BlackBG.TextColor = Colors.Purple;
                RedBG.TextColor = Colors.Purple;
                PurpleBG.TextColor = Colors.Purple;
                textColourLabel.TextColor = Colors.Purple;
                WhiteTC.TextColor = Colors.Purple;
                BlackTC.TextColor = Colors.Purple;
                RedTC.TextColor = Colors.Purple;
                PurpleTC.TextColor = Colors.Purple;
            }
        }

        
    }
}