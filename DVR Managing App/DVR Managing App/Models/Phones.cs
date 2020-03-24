using System;
using SQLite;

namespace DVR_Managing_App.Models
{
    class Phones
    {
        [PrimaryKey, AutoIncrement]
        public long phoneId { get; set; }
        [NotNull]
        public string phoneName { get; set; }
        [NotNull]
        public DateTime phoneAddDt { get; set; }
    }
}
