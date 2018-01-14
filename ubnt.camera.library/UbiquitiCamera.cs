using System;

using Newtonsoft.Json;


namespace chad.home.ubnt.camera
{
    public class UbiquitiCamera
    {
        #region Properties

        [JsonProperty("_id")]
        public String Id { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("host")]
        public String Host { get; set; }

        [JsonProperty("model")]
        public String Model { get; set; }

        [JsonProperty("mac")]
        public String Mac { get; set; }

        [JsonProperty("state")]
        public String State { get; set;  }

        [JsonProperty("disconnectReason")]
        public String DisconnectReason { get; set; }

        [JsonProperty("micVolume")]
        public String MicVolume { get; set; }

        [JsonProperty("platform")]
        public String Platform { get; set; }

        [JsonProperty("lastRecordingId")]
        public String LastRecordingId { get; set; }

        [JsonConverter(typeof(FromUnixTimeConverter))]
        [JsonProperty("lastRecordingStartTime")]
        public DateTime LastRecordingStartTime { get; set; }

        [JsonConverter(typeof(FromUnixTimeConverter))]
        [JsonProperty("lastSeen")]
        public DateTime LastSeen { get; set; }

        public UbiquitiCameraRecordingSettings recordingSettings { get; set; }

        public NvrRecording LastRecording { get; set; }
        
        #endregion

        public Object GetCameraStream()
        {
            throw new NotImplementedException();
        }

        public Object GetCameraSnapshot()
        {
            throw new NotImplementedException();
        }
        
    }

    public class UbiquitiCameraRecordingSettings
    {
        public Boolean motionRecordEnabled { get; set; }
        public Boolean fullTimeRecordEnabled { get; set; }
        public int channel { get; set; }
        public int prePaddingSecs { get; set; }
        public int postPaddingSecs { get; set; }
        public String storagePath { get; set; }
    }
}
