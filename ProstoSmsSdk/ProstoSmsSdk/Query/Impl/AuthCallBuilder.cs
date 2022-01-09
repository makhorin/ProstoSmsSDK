using System;

namespace ProstoSmsSdk.Query.Impl
{
    internal class AuthCallBuilder : BasePushMessage, IAuthCallBuilder
    {
        internal AuthCallBuilder(string apiKey, string baseUrl) : base(apiKey, baseUrl)
        {
            Parameters["route"] = "pc";
        }

        internal AuthCallBuilder(string email, string password, string baseUrl) : base(email, password, baseUrl)
        {
            Parameters["route"] = "pc";
        }

        public IFromStep WithCode(string code)
        {
            if (code == null) throw new ArgumentNullException(nameof(code));
            code = code.Trim();
            if (code.Length < 3 || code.Length > 4 || !ushort.TryParse(code, out _))
                throw new ArgumentException(
                    "Для использования данного функционала допускаются только 3-х значные (диапазон 001-999) или 4-х значные (диапазон 0000-9999) коды");

            Parameters["text"] = $"Ваш код авторизации: {code}";
            return this;
        }
    }
}
