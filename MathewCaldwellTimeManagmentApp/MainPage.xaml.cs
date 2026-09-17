using System.Diagnostics;

namespace MathewCaldwellTimeManagmentApp
{
    public partial class MainPage : ContentPage
    {
        List<string> timeList = new List<string>();
        TimeTrackerData timeData = new TimeTrackerData();
        Task taskSelected;
        
        public MainPage()
        {
            InitializeComponent();

            startTimerBtn.IsVisible = false;
            timerLabel.IsVisible = false;
            
            timeData.TestData();
            foreach(Task task in TimeTrackerData.taskList)
            {
                timeList.Add(task.name);
            }
            taskListView.ItemsSource = timeList;
        }

        private void taskListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            startTimerBtn.IsVisible = true;
            timerLabel.IsVisible = true;
            string selected = (string)taskListView.SelectedItem;
            foreach(Task task in TimeTrackerData.taskList)
            {
                if(task.name == selected)
                {
                    taskSelected = task;
                }
            }

            if (taskSelected.isTiming)
            {
                startTimerBtn.BackgroundColor = Colors.DarkRed;
                startTimerBtn.Text = "Stop";
            }
            else
            {
                startTimerBtn.BackgroundColor = Colors.DarkOliveGreen;
                startTimerBtn.Text = "Start";
            }

            timerLabel.Text = taskSelected.timeElapsed.ToString();

            Debug.WriteLine(timeData.TimeSinceLastRecorded(taskSelected));
        }

        private void TimerStartStop_Clicked(object sender, EventArgs e)
        {
            taskSelected.isTiming = !taskSelected.isTiming;

            if (taskSelected.isTiming)
            {
                startTimerBtn.BackgroundColor = Colors.DarkRed;
                startTimerBtn.Text = "Stop";
            }
            else
            {
                startTimerBtn.BackgroundColor = Colors.DarkOliveGreen;
                startTimerBtn.Text = "Start";
            }
        }
    }
}
