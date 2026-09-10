using System.Diagnostics;

namespace MathewCaldwellTimeManagmentApp
{
    public partial class MainPage : ContentPage
    {
        public List<string> timeList = new List<string>();
        bool timerStarted = false;
        
        public MainPage()
        {
            InitializeComponent();

            startTimerBtn.IsVisible = false;
            timerLabel.IsVisible = false;

            TimeTrackerData timeData = new TimeTrackerData();
            timeData.TestData();
            timeList = timeData.taskList;
            taskListView.ItemsSource = timeList;
        }

        private void taskListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            startTimerBtn.IsVisible = true;
            timerLabel.IsVisible = true;
        }

        private void TimerStartStop_Clicked(object sender, EventArgs e)
        {
            timerStarted = !timerStarted;

            if (timerStarted)
            {
                startTimerBtn.BackgroundColor = Colors.MediumVioletRed;
            }
            else
            {
                startTimerBtn.BackgroundColor = Colors.DarkOliveGreen;
            }
        }
    }
}
