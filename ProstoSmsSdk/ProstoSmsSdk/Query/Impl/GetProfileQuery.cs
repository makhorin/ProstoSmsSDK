using ProstoSmsSdk.Responses;

namespace ProstoSmsSdk.Query.Impl
{
    public class GetProfileQuery : BaseQuery<GetProfileResponse>
    {
        public GetProfileQuery(string apiKey, string baseUrl) : base(apiKey, baseUrl)
        {
            Parameters["method"] = "get_profile";
        }

        public GetProfileQuery(string email, string password, string baseUrl) : base(email, password, baseUrl)
        {
            Parameters["method"] = "get_profile";
        }
    }
}
