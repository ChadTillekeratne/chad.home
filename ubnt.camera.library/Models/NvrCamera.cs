// Generated with: https://app.quicktype.io/#r=json2csharp


using System;
using System.Net;
using System.Collections.Generic;

namespace chad.home.ubnt.camera.Models.Camera
{


    using Newtonsoft.Json;

    public partial class Welcome
    {
        [JsonProperty("data")]
        public Datum[] Data { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("uptime")]
        public long Uptime { get; set; }

        [JsonProperty("firmwareVersion")]
        public string FirmwareVersion { get; set; }

        [JsonProperty("firmwareBuild")]
        public string FirmwareBuild { get; set; }

        [JsonProperty("protocolVersion")]
        public long ProtocolVersion { get; set; }

        [JsonProperty("systemInfo")]
        public SystemInfo SystemInfo { get; set; }

        [JsonProperty("mac")]
        public string Mac { get; set; }

        [JsonProperty("managed")]
        public bool Managed { get; set; }

        [JsonProperty("provisioned")]
        public bool Provisioned { get; set; }

        [JsonProperty("unmanagementRequested")]
        public bool UnmanagementRequested { get; set; }

        [JsonProperty("lastSeen")]
        public long LastSeen { get; set; }

        [JsonProperty("internalHost")]
        public string InternalHost { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("disconnectReason")]
        public object DisconnectReason { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("managementToken")]
        public object ManagementToken { get; set; }

        [JsonProperty("controllerHostAddress")]
        public string ControllerHostAddress { get; set; }

        [JsonProperty("controllerHostPort")]
        public long ControllerHostPort { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("lastRecordingId")]
        public string LastRecordingId { get; set; }

        [JsonProperty("lastRecordingStartTime")]
        public long LastRecordingStartTime { get; set; }

        [JsonProperty("deviceSettings")]
        public DeviceSettings DeviceSettings { get; set; }

        [JsonProperty("enableSuggestedVideoSettings")]
        public bool EnableSuggestedVideoSettings { get; set; }

        [JsonProperty("micVolume")]
        public long MicVolume { get; set; }

        [JsonProperty("audioBitRate")]
        public long AudioBitRate { get; set; }

        [JsonProperty("channels")]
        public Channel[] Channels { get; set; }

        [JsonProperty("ispSettings")]
        public IspSettings IspSettings { get; set; }

        [JsonProperty("osdSettings")]
        public OsdSettings OsdSettings { get; set; }

        [JsonProperty("recordingSettings")]
        public RecordingSettings RecordingSettings { get; set; }

        [JsonProperty("scheduleId")]
        public object ScheduleId { get; set; }

        [JsonProperty("zones")]
        public Zone[] Zones { get; set; }

        [JsonProperty("mapSettings")]
        public MapSettings MapSettings { get; set; }

        [JsonProperty("networkStatus")]
        public NetworkStatus NetworkStatus { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("authToken")]
        public AuthToken AuthToken { get; set; }

        [JsonProperty("certSignature")]
        public string CertSignature { get; set; }

        [JsonProperty("hasDefaultCredentials")]
        public bool HasDefaultCredentials { get; set; }

        [JsonProperty("analyticsSettings")]
        public AnalyticsSettings AnalyticsSettings { get; set; }

        [JsonProperty("enableStatusLed")]
        public bool EnableStatusLed { get; set; }

        [JsonProperty("ledFaceAlwaysOnWhenManaged")]
        public bool LedFaceAlwaysOnWhenManaged { get; set; }

        [JsonProperty("enableSpeaker")]
        public bool EnableSpeaker { get; set; }

        [JsonProperty("systemSoundsEnabled")]
        public bool SystemSoundsEnabled { get; set; }

        [JsonProperty("speakerVolume")]
        public long SpeakerVolume { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("authStatus")]
        public string AuthStatus { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }
    }

    public partial class AnalyticsSettings
    {
        [JsonProperty("enableSoundAlert")]
        public bool EnableSoundAlert { get; set; }

        [JsonProperty("soundAlertVolume")]
        public long SoundAlertVolume { get; set; }

        [JsonProperty("minimumMotionSecs")]
        public long MinimumMotionSecs { get; set; }

        [JsonProperty("endMotionAfterSecs")]
        public long EndMotionAfterSecs { get; set; }
    }

    public partial class AuthToken
    {
        [JsonProperty("authToken")]
        public string PurpleAuthToken { get; set; }
    }

    public partial class Channel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("isRtspEnabled")]
        public bool IsRtspEnabled { get; set; }

        [JsonProperty("rtspAlias")]
        public object RtspAlias { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("fps")]
        public long Fps { get; set; }

        [JsonProperty("bitrate")]
        public long Bitrate { get; set; }

        [JsonProperty("minBitrate")]
        public long MinBitrate { get; set; }

        [JsonProperty("maxBitrate")]
        public long MaxBitrate { get; set; }

        [JsonProperty("fpsValues")]
        public long[] FpsValues { get; set; }

        [JsonProperty("idrInterval")]
        public long IdrInterval { get; set; }
    }

    public partial class DeviceSettings
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("persists")]
        public bool Persists { get; set; }
    }

    public partial class IspSettings
    {
        [JsonProperty("brightness")]
        public long Brightness { get; set; }

        [JsonProperty("contrast")]
        public long Contrast { get; set; }

        [JsonProperty("denoise")]
        public long Denoise { get; set; }

        [JsonProperty("hue")]
        public long Hue { get; set; }

        [JsonProperty("saturation")]
        public long Saturation { get; set; }

        [JsonProperty("sharpness")]
        public long Sharpness { get; set; }

        [JsonProperty("flip")]
        public long Flip { get; set; }

        [JsonProperty("mirror")]
        public long Mirror { get; set; }

        [JsonProperty("gamma")]
        public object Gamma { get; set; }

        [JsonProperty("wdr")]
        public long Wdr { get; set; }

        [JsonProperty("aeMode")]
        public string AeMode { get; set; }

        [JsonProperty("irLedMode")]
        public string IrLedMode { get; set; }

        [JsonProperty("irLedLevel")]
        public long IrLedLevel { get; set; }

        [JsonProperty("focusMode")]
        public string FocusMode { get; set; }

        [JsonProperty("focusPosition")]
        public long FocusPosition { get; set; }

        [JsonProperty("zoomPosition")]
        public long ZoomPosition { get; set; }

        [JsonProperty("icrSensitivity")]
        public long IcrSensitivity { get; set; }

        [JsonProperty("aggressiveAntiFlicker")]
        public long AggressiveAntiFlicker { get; set; }

        [JsonProperty("enable3dnr")]
        public long Enable3Dnr { get; set; }

        [JsonProperty("dZoomStreamId")]
        public long DZoomStreamId { get; set; }

        [JsonProperty("dZoomCenterX")]
        public long DZoomCenterX { get; set; }

        [JsonProperty("dZoomCenterY")]
        public long DZoomCenterY { get; set; }

        [JsonProperty("dZoomScale")]
        public long DZoomScale { get; set; }

        [JsonProperty("lensDistortionCorrection")]
        public long LensDistortionCorrection { get; set; }

        [JsonProperty("enableExternalIr")]
        public long EnableExternalIr { get; set; }

        [JsonProperty("irOnValBrightness")]
        public long IrOnValBrightness { get; set; }

        [JsonProperty("irOnStsBrightness")]
        public long IrOnStsBrightness { get; set; }

        [JsonProperty("irOnValContrast")]
        public long IrOnValContrast { get; set; }

        [JsonProperty("irOnStsContrast")]
        public long IrOnStsContrast { get; set; }

        [JsonProperty("irOnValDenoise")]
        public long IrOnValDenoise { get; set; }

        [JsonProperty("irOnStsDenoise")]
        public long IrOnStsDenoise { get; set; }

        [JsonProperty("irOnValHue")]
        public long IrOnValHue { get; set; }

        [JsonProperty("irOnStsHue")]
        public long IrOnStsHue { get; set; }

        [JsonProperty("irOnValSaturation")]
        public long IrOnValSaturation { get; set; }

        [JsonProperty("irOnStsSaturation")]
        public long IrOnStsSaturation { get; set; }

        [JsonProperty("irOnValSharpness")]
        public long IrOnValSharpness { get; set; }

        [JsonProperty("irOnStsSharpness")]
        public long IrOnStsSharpness { get; set; }
    }

    public partial class MapSettings
    {
        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }

        [JsonProperty("mapId")]
        public string MapId { get; set; }

        [JsonProperty("angle")]
        public long Angle { get; set; }

        [JsonProperty("radius")]
        public long Radius { get; set; }

        [JsonProperty("rotation")]
        public long Rotation { get; set; }
    }

    public partial class NetworkStatus
    {
        [JsonProperty("connectionState")]
        public long ConnectionState { get; set; }

        [JsonProperty("connectionStateDescription")]
        public string ConnectionStateDescription { get; set; }

        [JsonProperty("essid")]
        public object Essid { get; set; }

        [JsonProperty("frequency")]
        public long Frequency { get; set; }

        [JsonProperty("quality")]
        public long Quality { get; set; }

        [JsonProperty("qualityMax")]
        public long QualityMax { get; set; }

        [JsonProperty("signalLevel")]
        public long SignalLevel { get; set; }

        [JsonProperty("linkSpeedMbps")]
        public long LinkSpeedMbps { get; set; }

        [JsonProperty("ipAddress")]
        public string IpAddress { get; set; }
    }

    public partial class OsdSettings
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("overrideMessage")]
        public bool OverrideMessage { get; set; }

        [JsonProperty("enableDate")]
        public long EnableDate { get; set; }

        [JsonProperty("enableLogo")]
        public long EnableLogo { get; set; }
    }

    public partial class RecordingSettings
    {
        [JsonProperty("motionRecordEnabled")]
        public bool MotionRecordEnabled { get; set; }

        [JsonProperty("fullTimeRecordEnabled")]
        public bool FullTimeRecordEnabled { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("prePaddingSecs")]
        public long PrePaddingSecs { get; set; }

        [JsonProperty("postPaddingSecs")]
        public long PostPaddingSecs { get; set; }

        [JsonProperty("storagePath")]
        public object StoragePath { get; set; }
    }

    public partial class Status
    {
        [JsonProperty("recordingStatus")]
        public RecordingStatus RecordingStatus { get; set; }

        [JsonProperty("scheduledAction")]
        public object ScheduledAction { get; set; }

        [JsonProperty("remoteHost")]
        public string RemoteHost { get; set; }

        [JsonProperty("remotePort")]
        public long RemotePort { get; set; }
    }

    public partial class RecordingStatus
    {
        [JsonProperty("0")]
        public The0 The0 { get; set; }

        [JsonProperty("1")]
        public The0 The1 { get; set; }

        [JsonProperty("2")]
        public The0 The2 { get; set; }
    }

    public partial class The0
    {
        [JsonProperty("motionRecordingEnabled")]
        public bool MotionRecordingEnabled { get; set; }

        [JsonProperty("fullTimeRecordingEnabled")]
        public bool FullTimeRecordingEnabled { get; set; }
    }

    public partial class SystemInfo
    {
        [JsonProperty("cpuName")]
        public string CpuName { get; set; }

        [JsonProperty("cpuLoad")]
        public long CpuLoad { get; set; }

        [JsonProperty("memory")]
        public Memory Memory { get; set; }

        [JsonProperty("appMemory")]
        public object AppMemory { get; set; }

        [JsonProperty("nics")]
        public Nic[] Nics { get; set; }

        [JsonProperty("disk")]
        public object Disk { get; set; }
    }

    public partial class Memory
    {
        [JsonProperty("used")]
        public long Used { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }

    public partial class Nic
    {
        [JsonProperty("desc")]
        public string Desc { get; set; }

        [JsonProperty("mac")]
        public string Mac { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("rxBps")]
        public long RxBps { get; set; }

        [JsonProperty("txBps")]
        public long TxBps { get; set; }
    }

    public partial class Zone
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sensitivity")]
        public long Sensitivity { get; set; }

        [JsonProperty("bitmap")]
        public object Bitmap { get; set; }

        [JsonProperty("coordinates")]
        public Coordinate[] Coordinates { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }
    }

    public partial class Coordinate
    {
        [JsonProperty("x")]
        public long X { get; set; }

        [JsonProperty("y")]
        public long Y { get; set; }
    }

    public partial class Meta
    {
        [JsonProperty("totalCount")]
        public long TotalCount { get; set; }

        [JsonProperty("filteredCount")]
        public long FilteredCount { get; set; }
    }

    public partial class Welcome
    {
        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
