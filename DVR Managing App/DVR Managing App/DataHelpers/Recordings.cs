using System;
using System.Collections.Generic;
using System.Text;

namespace DVR_Managing_App.DataHelpers
{
    class Recordings
    {
        public long fileId {get; set;}
        public string fileName {get; set;}
        public int fileType {get; set;}
        public string fileFormat {get; set;}
        public string googleDriveId {get; set;}
        public DateTime dateRecorded {get; set;}
        public string resolution {get; set;}
        public string deviceRecordedWith {get; set;}
    }
}
