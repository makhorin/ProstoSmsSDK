using System;
using ProstoSmsSdk.Responses;

namespace ProstoSmsSdk.Query.Impl
{
    internal abstract class BasePushMessage : BaseQuery<PushMessageResponse>, IToStep, IFromStep, IAdditionalOptionsStep
    {
        protected BasePushMessage(string apiKey, string baseUrl) : base(apiKey, baseUrl)
        {
            Parameters["method"] = "push_msg";
        }

        protected BasePushMessage(string email, string password, string baseUrl) : base(email, password, baseUrl)
        {
            Parameters["method"] = "push_msg";
        }


        public IAdditionalOptionsStep WithPriority(Priority priority)
        {
            if (priority < Priority.Asap || priority > Priority.Bulk)
                throw new ArgumentException("Неправильное значение приоритета", nameof(priority));
            Parameters["priority"] = ((byte)priority).ToString();
            return this;
        }

        public IAdditionalOptionsStep WithExternalId(string externalId)
        {
            Parameters["external_id"] = externalId;
            return this;
        }

        public IAdditionalOptionsStep To(string phoneNumber)
        {
            Parameters["phone"] = phoneNumber;
            return this;
        }

        public IToStep From(string senderName)
        {
            if (senderName.Length > 11) throw new ArgumentException("Максимальная длина имени отправителя 11 символов");
            Parameters["sender_name"] = senderName;
            return this;
        }
    }
}
