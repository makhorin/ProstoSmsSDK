using System.Runtime.Serialization;

namespace ProstoSmsSdk.Responses
{
    [DataContract]
    public class WaitCallResponse
    {
        [DataMember(Name = "call_to_number")]
        public string CallToNumber { get; set; }
        [DataMember(Name = "waiting_call_from")]
        public string WaitingCallFrom { get; set; }
        [DataMember(Name = "id_call")]
        public string CallId { get; set; }
    }
}
