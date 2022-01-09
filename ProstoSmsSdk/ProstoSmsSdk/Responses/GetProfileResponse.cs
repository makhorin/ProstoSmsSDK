using System.Runtime.Serialization;

namespace ProstoSmsSdk.Responses
{
    [DataContract]
    public class GetProfileResponse
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }
        [DataMember(Name = "last_name")]
        public string LastName { get; set; }
        [DataMember(Name = "credits")]
        public decimal Credits { get; set; }
        [DataMember(Name = "credits_used")]
        public decimal CreditsUsed { get; set; }
        [DataMember(Name = "credits_name")]
        public string CreditsName { get; set; }
        [DataMember(Name = "currency")]
        public string Currency { get; set; }
        [DataMember(Name = "sender_name")]
        public string SenderName { get; set; }
        [DataMember(Name = "referral_id")]
        public string ReferralId { get; set; }

    }
}
