using System;
using SQLite;

namespace DVR_Managing_App.DataHelpers
{
    class Recordings
    {
        [PrimaryKey, AutoIncrement, NotNull, Unique]
        public long fileId {get; set;}
        [Unique, NotNull]
        public string fileName {get; set;}
        [NotNull]
        public int fileType {get; set;}
        [NotNull]
        public string fileFormat {get; set;}
        [NotNull]
        public string googleDriveId {get; set;}
        [NotNull]
        public DateTime dateRecorded {get; set;}
        [NotNull]
        public string resolution {get; set;}
        [NotNull]
        public string deviceRecordedWith {get; set;}
    }
}
