using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Mathew_Caldwell_Media_Tracker
{
    public class Media
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public string title { get; set; }
        public MediaTypes type { get; set; }
        public bool finished { get; set; } = false;
        public string releaseDate {  get; set; } = DateOnly.FromDateTime(DateTime.Now).ToString("yyyy-MM-dd");
        public string author { get; set; }
        public string streamingService { get; set; }
    }
}
