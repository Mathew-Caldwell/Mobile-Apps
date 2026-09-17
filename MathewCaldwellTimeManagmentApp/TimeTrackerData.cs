using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace MathewCaldwellTimeManagmentApp
{
    public class TimeTrackerData
    {
        public static List<Task> taskList = new List<Task>();

        public void TestData()
        {
            taskList.Add(new Task("Work around the house"));
            taskList.Add(new Task("Write novel"));
            taskList.Add(new Task("Do homework"));
        }

        public float PercentComparedToRest(Task task)
        {
            float total = 0;
            foreach(Task t in taskList)
            {
                total += t.timeElapsed;
            }

            float percentTaken = (float)Math.Round((task.timeElapsed / total) * 100, 2);
            
            return percentTaken;
        }

        public float AverageAmountPerWeek(Task task)
        {
            DateOnly now = DateOnly.FromDateTime(DateTime.Now);
            int numWeeks = now.DayNumber - task.startDate.DayNumber / 7;
            float avgPerWeek = (float)Math.Round(task.timeElapsed / numWeeks, 2);            
            return avgPerWeek;
        }

        public float AverageAmountPerDay(Task task)
        {
            DateOnly now = DateOnly.FromDateTime(DateTime.Now);
            int numDays = now.DayNumber - task.startDate.DayNumber;
            float avgPerDay = (float)Math.Round(task.timeElapsed / numDays, 2);
            return avgPerDay;
        }

        public string TimeSinceLastRecorded(Task task)
        {
            DateOnly now = DateOnly.FromDateTime(DateTime.Now);
            int diffInDays = now.DayNumber - task.startDate.DayNumber;
            if(diffInDays == 0)
            {
                return "Just now";
            }
            else if(diffInDays == 1)
            {
                return "Yesterday";
            }
            else if(diffInDays > 1 && diffInDays < 7)
            {
                return "Couple days ago";
            }
            else if(diffInDays >= 7 && diffInDays < 14)
            {
                return "Last week";
            }
            else
            {
                return "A while ago";
            }
        }
    }
}
