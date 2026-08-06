using System;
using System.Collections.Generic;
using System.Text;

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
        int numMinutesToday;
        int numMinutesTotal;
        int numMinutesPerDay;

        public void CalculateAvgMinForRestOfYear()
        {

        }

        public void CalculateTotalNumOfMinShouldHaveDone()
        {

        }

        public void CalculateAvgMinPerDay()
        {

        }

        public void ConvertMinToHours()
        {

        }

        public void IncrementMinDoneToday()
        {

        }

        public void IsNewDay()
        {

        }

        public void IsNewYear()
        {
            ResetData();
        }
        
        public void save()
        {

        }

        public void load()
        {

        }

        public void ResetData()
        {

        }
    }
}
