using System;
using System.Collections.Generic;
using System.Text;

namespace MathewCaldwellTimeManagmentApp
{
    public class Task
    {
        public string name;
        public bool isTiming;
        public float timeElapsed;
        public DateOnly startDate;

        public Task(string name)
        {
            this.name = name;
            this.isTiming = false;
            this.timeElapsed = 0;
            this.startDate = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
