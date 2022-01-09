using ProstoSmsSdk.Responses;

namespace ProstoSmsSdk.Query.Impl
{
    internal class GetStatusQuery : BaseQuery<GetStatusResponse>
    {
        public GetStatusQuery(int msgId, string apiKey, string baseUrl) : base(apiKey, baseUrl)
        {
            Parameters["method"] = "get_msg_report";
            Parameters["id"] = msgId.ToString();
        }

        public GetStatusQuery(int msgId, string email, string password, string baseUrl) : base(email, password, baseUrl)
        {
            Parameters["method"] = "get_msg_report";
            Parameters["id"] = msgId.ToString();
        }
    }
}
