using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MobileComms_ITK.JSON.Types
{



    public partial class Timestamp
    {
        [Newtonsoft.Json.JsonProperty("millis", Required = Newtonsoft.Json.Required.Always)]
        public long Millis { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Timestamp FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Timestamp>(data);
        }

    }
    public partial class Audit
    {
        [Newtonsoft.Json.JsonProperty("namekey")]
        public string Namekey { get; set; }

        [Newtonsoft.Json.JsonProperty("crt", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public Timestamp Crt { get; set; } = new Timestamp();

        [Newtonsoft.Json.JsonProperty("upd")]
        public Timestamp Upd { get; set; }

        [Newtonsoft.Json.JsonProperty("ver", Required = Newtonsoft.Json.Required.Always)]
        public int Ver { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Audit FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Audit>(data);
        }

    }


    public partial class RestResponse
    {
        [Newtonsoft.Json.JsonProperty("code", Required = Newtonsoft.Json.Required.Always)]
        public int Code { get; set; }

        [Newtonsoft.Json.JsonProperty("entity")]
        public string Entity { get; set; }

        [Newtonsoft.Json.JsonProperty("id")]
        public string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("message")]
        public string Message { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static RestResponse FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<RestResponse>(data);
        }

    }

    public partial class WaitTaskCancelQuery
    {
        [Newtonsoft.Json.JsonProperty("namekey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Namekey { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("robot")]
        public string Robot { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static WaitTaskCancelQuery FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<WaitTaskCancelQuery>(data);
        }

    }
    public partial class WaitTaskStateQuery
    {
        [Newtonsoft.Json.JsonProperty("namekey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Namekey { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("code", Required = Newtonsoft.Json.Required.Always)]
        public int Code { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public string Description { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static WaitTaskStateQuery FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<WaitTaskStateQuery>(data);
        }

    }

    public partial class DataStoreItem
    {
        [Newtonsoft.Json.JsonProperty("namekey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Namekey { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("upd", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public Timestamp Upd { get; set; } = new Timestamp();

        [Newtonsoft.Json.JsonProperty("itemId", Required = Newtonsoft.Json.Required.Always)]
        public int ItemId { get; set; }

        [Newtonsoft.Json.JsonProperty("source")]
        public string Source { get; set; }

        [Newtonsoft.Json.JsonProperty("category")]
        public string Category { get; set; }

        [Newtonsoft.Json.JsonProperty("groupName")]
        public string GroupName { get; set; }

        [Newtonsoft.Json.JsonProperty("groupDescr")]
        public string GroupDescr { get; set; }

        [Newtonsoft.Json.JsonProperty("itemName")]
        public string ItemName { get; set; }

        [Newtonsoft.Json.JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("type")]
        public string Type { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static DataStoreItem FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<DataStoreItem>(data);
        }

    }
    public partial class DataStoreValue
    {
        [Newtonsoft.Json.JsonProperty("namekey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Namekey { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("upd", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public Timestamp Upd { get; set; } = new Timestamp();

        [Newtonsoft.Json.JsonProperty("value")]
        public string Value { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static DataStoreValue FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<DataStoreValue>(data);
        }

    }

    public partial class Goal
    {
        [Newtonsoft.Json.JsonProperty("namekey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Namekey { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("upd", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public Timestamp Upd { get; set; } = new Timestamp();

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Goal FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Goal>(data);
        }

    }
    public partial class JobCancel
    {
        [Newtonsoft.Json.JsonProperty("namekey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Namekey { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("cancelType")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public JobCancelCancelType CancelType { get; set; }

        [Newtonsoft.Json.JsonProperty("cancelValue")]
        public string CancelValue { get; set; }

        [Newtonsoft.Json.JsonProperty("cancelReason")]
        public string CancelReason { get; set; }

        [Newtonsoft.Json.JsonProperty("status")]
        public string Status { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static JobCancel FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<JobCancel>(data);
        }

    }
    public partial class JobHistory
    {
        [Newtonsoft.Json.JsonProperty("namekey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Namekey { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("upd", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public Timestamp Upd { get; set; } = new Timestamp();

        [Newtonsoft.Json.JsonProperty("jobId")]
        public string JobId { get; set; }

        [Newtonsoft.Json.JsonProperty("jobType")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public JobHistoryJobType JobType { get; set; }

        [Newtonsoft.Json.JsonProperty("queuedTimestamp")]
        public Timestamp QueuedTimestamp { get; set; }

        [Newtonsoft.Json.JsonProperty("completedTimestamp")]
        public Timestamp CompletedTimestamp { get; set; }

        [Newtonsoft.Json.JsonProperty("lastAssignedRobot")]
        public string LastAssignedRobot { get; set; }

        [Newtonsoft.Json.JsonProperty("status")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public JobHistoryStatus Status { get; set; }

        [Newtonsoft.Json.JsonProperty("failCount", Required = Newtonsoft.Json.Required.Always)]
        public int FailCount { get; set; }

        [Newtonsoft.Json.JsonProperty("linkedJob")]
        public string LinkedJob { get; set; }

        [Newtonsoft.Json.JsonProperty("cancelReason")]
        public string CancelReason { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static JobHistory FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<JobHistory>(data);
        }

    }
    public partial class Job
    {
        [Newtonsoft.Json.JsonProperty("namekey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Namekey { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("upd", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public Timestamp Upd { get; set; } = new Timestamp();

        [Newtonsoft.Json.JsonProperty("jobId")]
        public string JobId { get; set; }

        [Newtonsoft.Json.JsonProperty("jobType")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public JobType JobType { get; set; }

        [Newtonsoft.Json.JsonProperty("queuedTimestamp")]
        public Timestamp QueuedTimestamp { get; set; }

        [Newtonsoft.Json.JsonProperty("completedTimestamp")]
        public Timestamp CompletedTimestamp { get; set; }

        [Newtonsoft.Json.JsonProperty("lastAssignedRobot")]
        public string LastAssignedRobot { get; set; }

        [Newtonsoft.Json.JsonProperty("status")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public JobStatus Status { get; set; }

        [Newtonsoft.Json.JsonProperty("failCount", Required = Newtonsoft.Json.Required.Always)]
        public int FailCount { get; set; }

        [Newtonsoft.Json.JsonProperty("linkedJob")]
        public string LinkedJob { get; set; }

        [Newtonsoft.Json.JsonProperty("cancelReason")]
        public string CancelReason { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Job FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Job>(data);
        }

    }
    public partial class JobRequestDetail
    {
        [Newtonsoft.Json.JsonProperty("goal")]
        public string Goal { get; set; }

        [Newtonsoft.Json.JsonProperty("priority", Required = Newtonsoft.Json.Required.Always)]
        public int Priority { get; set; }

        [Newtonsoft.Json.JsonProperty("segmentType")]
        public string SegmentType { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static JobRequestDetail FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<JobRequestDetail>(data);
        }

    }
    public partial class JobRequest
    {
        [Newtonsoft.Json.JsonProperty("assignedJobId")]
        public string AssignedJobId { get; set; }

        [Newtonsoft.Json.JsonProperty("jobId")]
        public string JobId { get; set; }

        [Newtonsoft.Json.JsonProperty("defaultPriority", Required = Newtonsoft.Json.Required.Always)]
        public bool DefaultPriority { get; set; }

        [Newtonsoft.Json.JsonProperty("status")]
        public string Status { get; set; }

        [Newtonsoft.Json.JsonProperty("namekey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Namekey { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("details", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<JobRequestDetail> Details { get; set; } = new System.Collections.ObjectModel.Collection<JobRequestDetail>();

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static JobRequest FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<JobRequest>(data);
        }

    }
    public partial class ListJobRequestDetail : System.Collections.ObjectModel.Collection<JobRequestDetail>
    {
        [Newtonsoft.Json.JsonProperty("empty")]
        public bool Empty { get; set; }

        [Newtonsoft.Json.JsonProperty("traversableAgain")]
        public bool TraversableAgain { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static ListJobRequestDetail FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ListJobRequestDetail>(data);
        }

    }
    public partial class JobSegmentModify
    {
        [Newtonsoft.Json.JsonProperty("namekey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Namekey { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("segmentId")]
        public string SegmentId { get; set; }

        [Newtonsoft.Json.JsonProperty("segmentNamekey")]
        public string SegmentNamekey { get; set; }

        [Newtonsoft.Json.JsonProperty("priority", Required = Newtonsoft.Json.Required.Always)]
        public int Priority { get; set; }

        [Newtonsoft.Json.JsonProperty("goal")]
        public string Goal { get; set; }

        [Newtonsoft.Json.JsonProperty("status")]
        public string Status { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static JobSegmentModify FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<JobSegmentModify>(data);
        }

    }
    public partial class JobSegmentHistory
    {
        [Newtonsoft.Json.JsonProperty("namekey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Namekey { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("upd", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public Timestamp Upd { get; set; } = new Timestamp();

        [Newtonsoft.Json.JsonProperty("segmentId")]
        public string SegmentId { get; set; }

        [Newtonsoft.Json.JsonProperty("segmentType")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public JobSegmentHistorySegmentType SegmentType { get; set; }

        [Newtonsoft.Json.JsonProperty("status")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public JobSegmentHistoryStatus Status { get; set; }

        [Newtonsoft.Json.JsonProperty("subStatus")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public JobSegmentHistorySubStatus SubStatus { get; set; }

        [Newtonsoft.Json.JsonProperty("job")]
        public string Job { get; set; }

        [Newtonsoft.Json.JsonProperty("robot")]
        public string Robot { get; set; }

        [Newtonsoft.Json.JsonProperty("linkedJobSegment")]
        public string LinkedJobSegment { get; set; }

        [Newtonsoft.Json.JsonProperty("completedTimestamp")]
        public Timestamp CompletedTimestamp { get; set; }

        [Newtonsoft.Json.JsonProperty("priority")]
        public int Priority { get; set; }

        [Newtonsoft.Json.JsonProperty("goalName")]
        public string GoalName { get; set; }

        [Newtonsoft.Json.JsonProperty("seq", Required = Newtonsoft.Json.Required.Always)]
        public int Seq { get; set; }

        [Newtonsoft.Json.JsonProperty("cancelReason")]
        public string CancelReason { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static JobSegmentHistory FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<JobSegmentHistory>(data);
        }

    }
    public partial class JobSegment
    {
        [Newtonsoft.Json.JsonProperty("namekey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Namekey { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("upd", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public Timestamp Upd { get; set; } = new Timestamp();



        [Newtonsoft.Json.JsonProperty("segmentId")]
        public string SegmentId { get; set; }

        [Newtonsoft.Json.JsonProperty("segmentType")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public JobSegmentSegmentType SegmentType { get; set; }

        [Newtonsoft.Json.JsonProperty("status")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public JobSegmentStatus Status { get; set; }

        [Newtonsoft.Json.JsonProperty("subStatus")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public JobSegmentSubStatus SubStatus { get; set; }

        [Newtonsoft.Json.JsonProperty("job")]
        public string Job { get; set; }

        [Newtonsoft.Json.JsonProperty("robot")]
        public string Robot { get; set; }

        [Newtonsoft.Json.JsonProperty("linkedJobSegment")]
        public string LinkedJobSegment { get; set; }

        [Newtonsoft.Json.JsonProperty("completedTimestamp")]
        public Timestamp CompletedTimestamp { get; set; }
        
        [Newtonsoft.Json.JsonProperty("priority")]
        public int Priority { get; set; }

        [Newtonsoft.Json.JsonProperty("goalName")]
        public string GoalName { get; set; }

        [Newtonsoft.Json.JsonProperty("seq", Required = Newtonsoft.Json.Required.Always)]
        public int Seq { get; set; }

        [Newtonsoft.Json.JsonProperty("cancelReason")]
        public string CancelReason { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static JobSegment FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<JobSegment>(data);
        }

    }
    public partial class PickupDropoff
    {
        [Newtonsoft.Json.JsonProperty("namekey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Namekey { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("pickupGoal")]
        public string PickupGoal { get; set; }

        [Newtonsoft.Json.JsonProperty("pickupPriority", Required = Newtonsoft.Json.Required.Always)]
        public int PickupPriority { get; set; }

        [Newtonsoft.Json.JsonProperty("dropoffGoal")]
        public string DropoffGoal { get; set; }

        [Newtonsoft.Json.JsonProperty("dropoffPriority")]
        public int DropoffPriority { get; set; }

        [Newtonsoft.Json.JsonProperty("jobId")]
        public string JobId { get; set; }

        [Newtonsoft.Json.JsonProperty("status")]
        public string Status { get; set; }

        [Newtonsoft.Json.JsonProperty("assignedJobId")]
        public string AssignedJobId { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PickupDropoff FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PickupDropoff>(data);
        }

    }
    public partial class Pickup
    {
        [Newtonsoft.Json.JsonProperty("namekey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Namekey { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("goal")]
        public string Goal { get; set; }

        [Newtonsoft.Json.JsonProperty("priority", Required = Newtonsoft.Json.Required.Always)]
        public int Priority { get; set; }

        [Newtonsoft.Json.JsonProperty("jobId")]
        public string JobId { get; set; }

        [Newtonsoft.Json.JsonProperty("status")]
        public string Status { get; set; }

        [Newtonsoft.Json.JsonProperty("assignedJobId")]
        public string AssignedJobId { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Pickup FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Pickup>(data);
        }

    } 
    public partial class Dropoff
    {
        [Newtonsoft.Json.JsonProperty("namekey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Namekey { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("robot")]
        public string Robot { get; set; }

        [Newtonsoft.Json.JsonProperty("goal")]
        public string Goal { get; set; }

        [Newtonsoft.Json.JsonProperty("priority", Required = Newtonsoft.Json.Required.Always)]
        public int Priority { get; set; }

        [Newtonsoft.Json.JsonProperty("jobId")]
        public string JobId { get; set; }

        [Newtonsoft.Json.JsonProperty("status")]
        public string Status { get; set; }

        [Newtonsoft.Json.JsonProperty("assignedJobId")]
        public string AssignedJobId { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Dropoff FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Dropoff>(data);
        }

    }
    public partial class RobotFaultHistory
    {
        [Newtonsoft.Json.JsonProperty("namekey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Namekey { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("upd", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public Timestamp Upd { get; set; } = new Timestamp();

        [Newtonsoft.Json.JsonProperty("robot")]
        public string Robot { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("active", Required = Newtonsoft.Json.Required.Always)]
        public bool Active { get; set; }

        [Newtonsoft.Json.JsonProperty("type")]
        public string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("shortDescription")]
        public string ShortDescription { get; set; }

        [Newtonsoft.Json.JsonProperty("longDescription")]
        public string LongDescription { get; set; }

        [Newtonsoft.Json.JsonProperty("driving")]
        public bool Driving { get; set; }

        [Newtonsoft.Json.JsonProperty("critical")]
        public bool Critical { get; set; }

        [Newtonsoft.Json.JsonProperty("application")]
        public bool Application { get; set; }

        [Newtonsoft.Json.JsonProperty("clearedOnGo")]
        public bool ClearedOnGo { get; set; }

        [Newtonsoft.Json.JsonProperty("clearedOnAck")]
        public bool ClearedOnAck { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static RobotFaultHistory FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<RobotFaultHistory>(data);
        }

    }
    public partial class RobotFault
    {
        [Newtonsoft.Json.JsonProperty("namekey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Namekey { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("upd", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public Timestamp Upd { get; set; } = new Timestamp();

        [Newtonsoft.Json.JsonProperty("robot")]
        public string Robot { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("active", Required = Newtonsoft.Json.Required.Always)]
        public bool Active { get; set; }

        [Newtonsoft.Json.JsonProperty("type")]
        public string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("shortDescription")]
        public string ShortDescription { get; set; }

        [Newtonsoft.Json.JsonProperty("longDescription")]
        public string LongDescription { get; set; }

        [Newtonsoft.Json.JsonProperty("blockDriving")]
        public bool BlockDriving { get; set; }

        [Newtonsoft.Json.JsonProperty("driving")]
        public bool Driving { get; set; }

        [Newtonsoft.Json.JsonProperty("critical")]
        public bool Critical { get; set; }

        [Newtonsoft.Json.JsonProperty("application")]
        public bool Application { get; set; }

        [Newtonsoft.Json.JsonProperty("clearedOnGo")]
        public bool ClearedOnGo { get; set; }

        [Newtonsoft.Json.JsonProperty("clearedOnAck")]
        public bool ClearedOnAck { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static RobotFault FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<RobotFault>(data);
        }

    }
    public partial class RobotHistory
    {
        [Newtonsoft.Json.JsonProperty("namekey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Namekey { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("upd", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public Timestamp Upd { get; set; } = new Timestamp();

        [Newtonsoft.Json.JsonProperty("status")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public RobotHistoryStatus Status { get; set; }

        [Newtonsoft.Json.JsonProperty("subStatus")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public RobotHistorySubStatus SubStatus { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static RobotHistory FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<RobotHistory>(data);
        }

    }
    public partial class Robot
    {
        [Newtonsoft.Json.JsonProperty("namekey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Namekey { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("upd", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public Timestamp Upd { get; set; } = new Timestamp();

        [Newtonsoft.Json.JsonProperty("status")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public RobotStatus Status { get; set; }

        [Newtonsoft.Json.JsonProperty("subStatus")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public RobotSubStatus SubStatus { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Robot FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Robot>(data);
        }

    }
    public partial class SubscriptionConfig
    {
        [Newtonsoft.Json.JsonProperty("namekey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Namekey { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("subscriptionInterval")]
        public string SubscriptionInterval { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SubscriptionConfig FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SubscriptionConfig>(data);
        }

    }


    public enum Status
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Pending")]
        Pending = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"InProgress")]
        InProgress = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"Completed")]
        Completed = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"Cancelled")]
        Cancelled = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"Cancelling")]
        Cancelling = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"Modifying")]
        Modifying = 5,

    }


    public enum Status2
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Pending")]
        Pending = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"InProgress")]
        InProgress = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"Interrupted")]
        Interrupted = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"Completed")]
        Completed = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"Cancelled")]
        Cancelled = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"Cancelling")]
        Cancelling = 5,

        [System.Runtime.Serialization.EnumMember(Value = @"Failed")]
        Failed = 6,

        [System.Runtime.Serialization.EnumMember(Value = @"Modifying")]
        Modifying = 7,

        [System.Runtime.Serialization.EnumMember(Value = @"Modified")]
        Modified = 8,

        [System.Runtime.Serialization.EnumMember(Value = @"InterruptedByModify")]
        InterruptedByModify = 9,

    }


    public enum Status3
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Available")]
        Available = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"InProgress")]
        InProgress = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"Unavailable")]
        Unavailable = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"Unavailable_Busy")]
        Unavailable_Busy = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"Unavailable_NeedsAssistance")]
        Unavailable_NeedsAssistance = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"AvailableForJobs")]
        AvailableForJobs = 5,

    }


    public enum SubStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Unallocated")]
        Unallocated = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"Allocated")]
        Allocated = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"Available")]
        Available = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"Fault")]
        Fault = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"BeforePickup")]
        BeforePickup = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"BeforeDropoff")]
        BeforeDropoff = 5,

        [System.Runtime.Serialization.EnumMember(Value = @"BeforeEvery")]
        BeforeEvery = 6,

        [System.Runtime.Serialization.EnumMember(Value = @"Before")]
        Before = 7,

        [System.Runtime.Serialization.EnumMember(Value = @"Driving")]
        Driving = 8,

        [System.Runtime.Serialization.EnumMember(Value = @"After")]
        After = 9,

        [System.Runtime.Serialization.EnumMember(Value = @"AfterEvery")]
        AfterEvery = 10,

        [System.Runtime.Serialization.EnumMember(Value = @"AfterPickup")]
        AfterPickup = 11,

        [System.Runtime.Serialization.EnumMember(Value = @"AfterDropoff")]
        AfterDropoff = 12,

        [System.Runtime.Serialization.EnumMember(Value = @"ModeIsLocked")]
        ModeIsLocked = 13,

        [System.Runtime.Serialization.EnumMember(Value = @"Parking")]
        Parking = 14,

        [System.Runtime.Serialization.EnumMember(Value = @"Parked")]
        Parked = 15,

        [System.Runtime.Serialization.EnumMember(Value = @"Docking")]
        Docking = 16,

        [System.Runtime.Serialization.EnumMember(Value = @"Docked")]
        Docked = 17,

        [System.Runtime.Serialization.EnumMember(Value = @"DockParking")]
        DockParking = 18,

        [System.Runtime.Serialization.EnumMember(Value = @"DockParked")]
        DockParked = 19,

        [System.Runtime.Serialization.EnumMember(Value = @"ForcedDocking")]
        ForcedDocking = 20,

        [System.Runtime.Serialization.EnumMember(Value = @"ForcedDocked")]
        ForcedDocked = 21,

        [System.Runtime.Serialization.EnumMember(Value = @"Interrupted")]
        Interrupted = 22,

        [System.Runtime.Serialization.EnumMember(Value = @"InterruptedButNotYetIdle")]
        InterruptedButNotYetIdle = 23,

        [System.Runtime.Serialization.EnumMember(Value = @"OutgoingArclConnectionLost")]
        OutgoingArclConnectionLost = 24,

        [System.Runtime.Serialization.EnumMember(Value = @"EstopPressed")]
        EstopPressed = 25,

        [System.Runtime.Serialization.EnumMember(Value = @"EstopRelieved")]
        EstopRelieved = 26,

        [System.Runtime.Serialization.EnumMember(Value = @"MotorsDisabled")]
        MotorsDisabled = 27,

        [System.Runtime.Serialization.EnumMember(Value = @"Lost")]
        Lost = 28,

        [System.Runtime.Serialization.EnumMember(Value = @"AvailableForJobs")]
        AvailableForJobs = 29,

        [System.Runtime.Serialization.EnumMember(Value = @"Buffering")]
        Buffering = 30,

        [System.Runtime.Serialization.EnumMember(Value = @"Buffered")]
        Buffered = 31,

    }


    public enum JobCancelCancelType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"SegmentId, JobId, RobotName, Status, SegmentNamekey, JobNamekey, RemoveSegmentId, RemoveSegmentNamekey")]
        SegmentId__JobId__RobotName__Status__SegmentNamekey__JobNamekey__RemoveSegmentId__RemoveSegmentNamekey = 0,

    }

    public enum JobHistoryJobType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"P, D, PD, M")]
        P__D__PD__M = 0,

    }


    public enum JobHistoryStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Pending, InProgress, Completed, Cancelled, Cancelling, Modifying")]
        Pending__InProgress__Completed__Cancelled__Cancelling__Modifying = 0,

    }


    public enum JobType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"P, D, PD, M")]
        P__D__PD__M = 0,

    }


    public enum JobStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Pending, InProgress, Completed, Cancelled, Cancelling, Modifying")]
        Pending__InProgress__Completed__Cancelled__Cancelling__Modifying = 0,

    }


    public enum JobSegmentHistorySegmentType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Pickup, DropOff")]
        Pickup__DropOff = 0,

    }


    public enum JobSegmentHistoryStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Pending, InProgress, Interrupted, Completed, Cancelled, Cancelling, Failed, Modifying, Modified, InterruptedByModify")]
        Pending__InProgress__Interrupted__Completed__Cancelled__Cancelling__Failed__Modifying__Modified__InterruptedByModify = 0,

    }


    public enum JobSegmentHistorySubStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Unallocated, Allocated, BeforePickup, BeforeDropOff, BeforeEvery, Before, Driving, After, AfterEvery, AfterPickup, AfterDropOff, Buffering, Buffered, None, ContainsCancelReason, ContainsLinkedReason, AssignedRobotOffline, NoMatchingRobotForLinkedJob, NoMatchingRobotForOtherSegment, NoMatchingRobot")]
        Unallocated__Allocated__BeforePickup__BeforeDropOff__BeforeEvery__Before__Driving__After__AfterEvery__AfterPickup__AfterDropOff__Buffering__Buffered__None__ContainsCancelReason__ContainsLinkedReason__AssignedRobotOffline__NoMatchingRobotForLinkedJob__NoMatchingRobotForOtherSegment__NoMatchingRobot = 0,

    }


    public enum JobSegmentSegmentType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Pickup, DropOff")]
        Pickup__DropOff = 0,

    }


    public enum JobSegmentStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Pending, InProgress, Interrupted, Completed, Cancelled, Cancelling, Failed, Modifying, Modified, InterruptedByModify")]
        Pending__InProgress__Interrupted__Completed__Cancelled__Cancelling__Failed__Modifying__Modified__InterruptedByModify = 0,

    }


    public enum JobSegmentSubStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Unallocated, Allocated, BeforePickup, BeforeDropOff, BeforeEvery, Before, Driving, After, AfterEvery, AfterPickup, AfterDropOff, Buffering, Buffered, None, ContainsCancelReason, ContainsLinkedReason, AssignedRobotOffline, NoMatchingRobotForLinkedJob, NoMatchingRobotForOtherSegment, NoMatchingRobot")]
        Unallocated__Allocated__BeforePickup__BeforeDropOff__BeforeEvery__Before__Driving__After__AfterEvery__AfterPickup__AfterDropOff__Buffering__Buffered__None__ContainsCancelReason__ContainsLinkedReason__AssignedRobotOffline__NoMatchingRobotForLinkedJob__NoMatchingRobotForOtherSegment__NoMatchingRobot = 0,

    }


    public enum RobotHistoryStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Available, InProgress, Unavailable, Unavailable_Busy, Unavailable_NeedsAssistance, AvailableForJobs")]
        Available__InProgress__Unavailable__Unavailable_Busy__Unavailable_NeedsAssistance__AvailableForJobs = 0,

    }


    public enum RobotHistorySubStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Unallocated, Allocated, Available, Fault, BeforePickup, BeforeDropoff, BeforeEvery, Before, Driving, After, AfterEvery, AfterPickup, AfterDropoff, ModeIsLocked, Parking, Parked, Docking, Docked, DockParking, DockParked, ForcedDocking, ForcedDocked, Interrupted, InterruptedButNotYetIdle, OutgoingArclConnectionLost, EstopPressed, EstopRelieved, MotorsDisabled, Lost, AvailableForJobs, Buffering, Buffered")]
        Unallocated__Allocated__Available__Fault__BeforePickup__BeforeDropoff__BeforeEvery__Before__Driving__After__AfterEvery__AfterPickup__AfterDropoff__ModeIsLocked__Parking__Parked__Docking__Docked__DockParking__DockParked__ForcedDocking__ForcedDocked__Interrupted__InterruptedButNotYetIdle__OutgoingArclConnectionLost__EstopPressed__EstopRelieved__MotorsDisabled__Lost__AvailableForJobs__Buffering__Buffered = 0,

    }


    public enum RobotStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Available, InProgress, Unavailable, Unavailable_Busy, Unavailable_NeedsAssistance, AvailableForJobs")]
        Available__InProgress__Unavailable__Unavailable_Busy__Unavailable_NeedsAssistance__AvailableForJobs = 0,

    }


    public enum RobotSubStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Unallocated, Allocated, Available, Fault, BeforePickup, BeforeDropoff, BeforeEvery, Before, Driving, After, AfterEvery, AfterPickup, AfterDropoff, ModeIsLocked, Parking, Parked, Docking, Docked, DockParking, DockParked, ForcedDocking, ForcedDocked, Interrupted, InterruptedButNotYetIdle, OutgoingArclConnectionLost, EstopPressed, EstopRelieved, MotorsDisabled, Lost, AvailableForJobs, Buffering, Buffered")]
        Unallocated__Allocated__Available__Fault__BeforePickup__BeforeDropoff__BeforeEvery__Before__Driving__After__AfterEvery__AfterPickup__AfterDropoff__ModeIsLocked__Parking__Parked__Docking__Docked__DockParking__DockParked__ForcedDocking__ForcedDocked__Interrupted__InterruptedButNotYetIdle__OutgoingArclConnectionLost__EstopPressed__EstopRelieved__MotorsDisabled__Lost__AvailableForJobs__Buffering__Buffered = 0,

    }

}
