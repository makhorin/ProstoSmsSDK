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

        public IQuery<WaitCallResponse> WaitFor(TimeSpan waitTime)
        {
            int sec;
            unchecked
            {
                sec = (int)waitTime.TotalSeconds;
            }
            
            if (sec < 60 || sec > 300)
                throw new ArgumentException("Допустимые значения от 60 до 300", nameof(waitTime));
            Parameters["call_protection"] = sec.ToString();
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
