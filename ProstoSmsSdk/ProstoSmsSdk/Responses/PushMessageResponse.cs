using System.Runtime.Serialization;

namespace ProstoSmsSdk.Responses
{
    [DataContract]
    public class PushMessageResponse
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "credits")]
        public string Credits { get; set; }
        [DataMember(Name = "n_raw_sms")]
        public int RawSms { get; set; }
        [DataMember(Name = "sender_name")]
        public string SenderName { get; set; }
    }
}
