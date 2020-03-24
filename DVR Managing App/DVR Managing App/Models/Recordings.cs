using System;
using SQLite;

namespace DVR_Managing_App.DataHelpers
{
    ///
    class Recordings
    {
        ///
        [PrimaryKey, AutoIncrement, NotNull, Unique]
        public long fileId {get; set;}
        [Unique, NotNull]
        public string fileName {get; set;}
        /// <summary>
        /// 0 is a video.
        /// </summary>
        [NotNull]
        public int fileType {get; set;}
        /// <summary>
        /// Format of file itself, i.e. "mp4" no .
        /// </summary>
        [NotNull]
        public string fileFormat {get; set;}
        /// <summary>
        /// "1d3kl2hdol10a2dWxz" style id if it's been uploaded.
        /// </summary>
        [NotNull]
        public string googleDriveId {get; set;}
        [NotNull]
        public DateTime dateRecorded {get; set;}
        /// <summary>
        /// Not working, cant configure resolution :/
        /// </summary>
        [NotNull]
        public string resolution {get; set;}
        [NotNull]
        public string deviceRecordedWith {get; set;}
    }
}
