using System;
using SQLite;

namespace DVR_Managing_App.Models
{
    class Phones
    {
        [PrimaryKey, AutoIncrement]
        public long phoneId { get; set; }
        [NotNull]
        public string manufacturer { get; set; }
        [NotNull]
        public string phoneName { get; set; } 
        [NotNull]
        public string deviceName { get; set; }        
        public string osVersion { get; set; }
        public string platform { get; set; }
        [NotNull]
        public DateTime phoneAddDt { get; set; }
    }
}
