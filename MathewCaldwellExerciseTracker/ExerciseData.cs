using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;

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
    //   check if new day
    //   reset data
    internal class ExerciseData
    {
        public int numMinutesToday;
        public int numMinutesTotal;
        public int numMinutesPerDay;

        public string backgroundColour = "WhiteBG";
        public string textColour = "BlackTC";

        string fileName = "ExerciseData";
        string content = "";

        int year;
        int hour;

        public float CalculateAvgMinForRestOfYear()
        {
            int difference = DifferenceInDays(new DateTime(2026, 12,31), DateTime.Now);

            int totalMinInYear = 365 * numMinutesPerDay;
            int numMinRestOfYear = totalMinInYear - numMinutesToday;
            float avgMinForRestOfYear = numMinRestOfYear / difference;
            return avgMinForRestOfYear;
        }       

        public int CalculateTotalNumOfMinShouldHaveDone()
        {
            int difference = DifferenceInDays(new DateTime(2026,1,1), DateTime.Now);
            return difference * numMinutesPerDay;
        }

        public float CalculateAvgMinPerDay()
        {
            int difference = DifferenceInDays(new DateTime(2026, 1, 1), DateTime.Now);

            float AvgMinDonePerDay = numMinutesToday / difference;
            return AvgMinDonePerDay;
        }

        public string ConvertMinToHours(float min)
        {
            TimeSpan time = TimeSpan.FromMinutes(min);
            string formattedTime = $"{Math.Round((double)time.TotalHours, 2)}";
            return formattedTime;
        }

        public void IncrementMinDone(int newMinutesDone)
        {
            numMinutesToday += newMinutesDone;
            numMinutesTotal += newMinutesDone;
        }

        void IsNewDay(int hour)
        {
            int currentHour = DateTime.Now.Hour;
            if(currentHour < hour)
            {
                numMinutesToday = 0;
            }
        }

        void IsNewYear(int year)
        {
            int currentYear = DateTime.Now.Year;
            if (currentYear > year)
            {
                ResetData();
            }
        }

        public void ResetData()
        {
            numMinutesToday = 0;
            numMinutesTotal = 0;
            numMinutesPerDay = 30;
            backgroundColour = "WhiteBG";
            textColour = "BlackTC";
        }

        public void save()
        {
            DateTime now = DateTime.Now;
            year = now.Year;
            hour = now.Hour;
            
            content = $"{numMinutesToday},{numMinutesTotal},{numMinutesPerDay},{backgroundColour},{textColour},{hour},{year}";
            
            var localFolder = FileSystem.Current.AppDataDirectory;
            var filePath = Path.Combine(localFolder, fileName);
            Debug.WriteLine(filePath);
            File.WriteAllText(filePath, content);
        }

        public void load()
        {
            var localFolder = FileSystem.Current.AppDataDirectory;
            try
            {
                var filePath = Path.Combine(localFolder, fileName);
                content = File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                content = $"0,0,30,WhiteBG,BlackTC,{DateTime.Now.Hour}, {DateTime.Now.Year}";
            }

            string[] contentArray = content.Split(",");
            numMinutesToday = int.Parse(contentArray[0]);
            numMinutesTotal = int.Parse(contentArray[1]);
            numMinutesPerDay = int.Parse(contentArray[2]);
            backgroundColour = contentArray[3];
            textColour = contentArray[4];
            hour = int.Parse(contentArray[5]);
            year = int.Parse(contentArray[6]);

            IsNewDay(hour);
            IsNewYear(year);
        }

        int DifferenceInDays(DateTime otherDate, DateTime now)
        {
            TimeSpan difference = otherDate - now;

            int daysBetween = Math.Abs(difference.Days);

            return daysBetween;
        }
    }
}
