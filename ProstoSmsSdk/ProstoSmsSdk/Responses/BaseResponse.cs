using System.Runtime.Serialization;

namespace ProstoSmsSdk.Responses
{
    [DataContract]
    internal class BaseResponse<T>
    {
        [DataMember(Name = "response")]
        public Response<T> Response { get; set; }
    }

    [DataContract]
    internal class Response<T>
    {
        [DataMember(Name = "msg")]
        public ResponseMsg Message { get; set; }

        [DataMember(Name = "data")]
        public T Data { get; set; }
    }
    
    [DataContract]
    internal class ResponseMsg
    {
        [DataMember(Name = "err_code")]
        public string ErrorCode { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}
