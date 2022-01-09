using System;
using ProstoSmsSdk.Responses;

namespace ProstoSmsSdk.Query.Impl
{
    internal class WaitCallBuilder : BaseQuery<WaitCallResponse>, IWaitCallBuilder, IWaitPeriodStep
    {
        public IWaitPeriodStep From(string phoneNumber)
        {
            Parameters["phone"] = phoneNumber;
            return this;
        }

        public IQuery<WaitCallResponse> WaitFor(ushort waitTime)
        {
            if (waitTime < 60 || waitTime > 300)
                throw new ArgumentException("Допустимые значения от 60 до 300", nameof(waitTime));
            Parameters["call_protection"] = waitTime.ToString();
            return this;
        }

        public WaitCallBuilder(string apiKey, string baseUrl) : base(apiKey, baseUrl)
        {
            Parameters["method"] = "wait_call";
        }

        public WaitCallBuilder(string email, string password, string baseUrl) : base(email, password, baseUrl)
        {
            Parameters["method"] = "wait_call";
        }
    }
}
