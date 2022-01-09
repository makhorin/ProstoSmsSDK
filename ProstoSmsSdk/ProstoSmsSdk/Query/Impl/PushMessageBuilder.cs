using System;

namespace ProstoSmsSdk.Query.Impl
{
    internal class PushMessageBuilder : BasePushMessage
        , IPushMessageBuilder
        , ISmsBuilder
        , IViberMessageBuilder
    {
        public PushMessageBuilder(string apiKey, string baseUrl) : base(apiKey, baseUrl)
        {
        }

        public PushMessageBuilder(string email, string password, string baseUrl) : base(email, password, baseUrl)
        {
        }


        public IViberMessageBuilder ToViber()
        {
            Parameters["route"] = "vb";
            return this;
        }

        public ISmsBuilder ToMobile()
        {
            Parameters["route"] = "sms";
            return this;
        }

        public ICascadeSenderStep ToVK()
        {
            Parameters["route"] = "vk";
            return this;
        }

        public ICascadeSenderStep ToTelegram()
        {
            Parameters["route"] = "tg";
            return this;
        }

        public ICascadeSenderStep ToWhatsApp()
        {
            Parameters["route"] = "wp";
            return this;
        }

        public IFromStep WithText(string text)
        {
            Parameters["text"] = text;
            return this;
        }

        public ISmsBuilder WithCallProtection(ushort callDelay)
        {
            if (callDelay < 60 || callDelay > 300)
                throw new ArgumentException("Допустимые значения от 60 до 300", nameof(callDelay));

            Parameters["call_protection"] = callDelay.ToString();
            return this;
        }

        public ICascadeSenderStep AndThenToMobile()
        {
            AddCascadeRoute("sms");
            return this;
        }

        public ICascadeSenderStep AndThenToVk()
        {
            AddCascadeRoute("vk");
            return this;
        }

        public ICascadeSenderStep AndThenToWhatsApp()
        {
            AddCascadeRoute("wp");
            return this;
        }

        public ICascadeSenderStep AndThenToTelegram()
        {
            AddCascadeRoute("tg");
            return this;
        }

        public ICascadeSenderStep AndThenToViber()
        {
            AddCascadeRoute("vb");
            return this;
        }

        public IViberMessageBuilder SetImage(string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl)) return this;
            Parameters["vb_img_url"] = imageUrl;
            return this;
        }

        public IViberMessageBuilder SetButton(string title, string url)
        {
            if (string.IsNullOrWhiteSpace(title) && string.IsNullOrWhiteSpace(url)) return this;
            Parameters["vb_btn_url"] = url ?? throw new ArgumentNullException(nameof(url));
            Parameters["vb_btn_title"] = title ?? throw new ArgumentNullException(nameof(title));
            return this;
        }

        private void AddCascadeRoute(string routeId)
        {
            var currentRoute = Parameters["route"];
            if (currentRoute.Contains("routeId")) return;
            Parameters["route"] = currentRoute + $"-{routeId}";
        }
    }
}
