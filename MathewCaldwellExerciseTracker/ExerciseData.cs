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

        public string backgroundColour = "white";
        public string textColour = "black";

        string fileName = "ExerciseData";
        string content = "";

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
            Debug.WriteLine(min);
            TimeSpan time = TimeSpan.FromMinutes(min);
            string formattedTime = $"{(double)time.TotalHours}";
            return formattedTime;
        }

        public void IncrementMinDone(int newMinutesDone)
        {
            numMinutesToday += newMinutesDone;
            numMinutesTotal += newMinutesDone;
        }

        public void IsNewDay()
        {

        }

        public void IsNewYear()
        {
            ResetData();
        }

        public void ResetData()
        {

        }

        public void save()
        {
            content = $"{numMinutesToday},{numMinutesTotal},{numMinutesPerDay},{backgroundColour},{textColour}";
            
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
                content = "0,0,30,white,black";
            }

            string[] contentArray = content.Split(",");
            numMinutesToday = int.Parse(contentArray[0]);
            numMinutesTotal = int.Parse(contentArray[1]);
            numMinutesPerDay = int.Parse(contentArray[2]);
            backgroundColour = contentArray[3];
            textColour = contentArray[4];
        }

        int DifferenceInDays(DateTime otherDate, DateTime now)
        {
            TimeSpan difference = otherDate - now;

            int daysBetween = Math.Abs(difference.Days);

            return daysBetween;
        }
    }
}
