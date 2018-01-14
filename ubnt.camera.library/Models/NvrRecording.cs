using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace chad.home.ubnt.camera
{
    public class NvrRecording
    {
        public NvrRecordingData[] data { get; set; }


        public NvrRecordingMeta meta { get; set; }
    }
    
    public class NvrRecordingData
    {
        public string eventType { get; set; }

        [JsonConverter(typeof(FromUnixTimeConverter))]
        public DateTime startTime { get; set; }

        [JsonConverter(typeof(FromUnixTimeConverter))]
        public DateTime endTime { get; set; }
        public String[] cameras { get; set; }
        public Boolean locked { get; set; }
        public Boolean inProgress { get; set; }
        public Boolean markedForDeletion { get; set; }
        
        public NvrRecordingDataMeta meta { get; set; }

        public String _id { get; set; }

    }

    public class NvrRecordingDataMeta
    {
        public String cameraName { get; set; }
        public String key { get; set; }
        public String recordingPathId { get; set; }
    }
    
    public class NvrRecordingMeta
    {
        public int totalCount { get; set; }
        public int filteredCount { get; set; }
    }
}
