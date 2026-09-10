using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace MathewCaldwellTimeManagmentApp
{
    public class TimeTrackerData
    {
        public List<string> taskList = new List<string>();

        public void TestData()
        {
            taskList.Add("Work around the house");
            taskList.Add("Write novel");
            taskList.Add("Do homework");
        }
    }
}
