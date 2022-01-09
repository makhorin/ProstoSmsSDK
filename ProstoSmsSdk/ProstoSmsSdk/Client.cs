using System;
using ProstoSmsSdk.Query;
using ProstoSmsSdk.Query.Impl;
using ProstoSmsSdk.Responses;

namespace ProstoSmsSdk
{
    public class Client
    {
        private readonly string _email;
        private readonly string _password;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        private Client(string apiKey, string baseUrl)
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            _baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
        }

        private Client(string email, string password, string baseUrl)
        {
            _email = email ?? throw new ArgumentNullException(nameof(email));
            _password = password ?? throw new ArgumentNullException(nameof(password));
            _baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
        }

        /// <summary>
        /// Создает клиент, который будет обращаться к  http://api.sms-prosto.ru
        /// </summary>
        /// <returns></returns>
        public static Client CreateHttpClient(string apiKey)
        {
            return new Client(apiKey, "http://api.sms-prosto.ru/");
        }

        /// <summary>
        /// Создает клиент, который будет обращаться к  http://api.sms-prosto.ru
        /// </summary>
        /// <returns></returns>
        public static Client CreateHttpsClient(string apiKey)
        {
            return new Client(apiKey, "https://ssl.bs00.ru/");
        }

        /// <summary>
        /// Создает клиент, который будет обращаться к https://ssl.bs00.ru
        /// </summary>
        /// <returns></returns>
        public static Client CreateHttpClient(string email, string password)
        {
            return new Client(email, password, "http://api.sms-prosto.ru/");
        }

        /// <summary>
        /// Создает клиент, который будет обращаться к https://ssl.bs00.ru
        /// </summary>
        /// <returns></returns>
        public static Client CreateHttpsClient(string email, string password)
        {
            return new Client(email, password, "https://ssl.bs00.ru/");
        }

        /// <summary>
        /// Отправить СМС или сообщение в мессенджеры. Подробнее: https://lk.sms-prosto.ru/help.php?faq=43
        /// </summary>
        /// <returns></returns>
        public IPushMessageBuilder PushMessage()
        {
            return _apiKey == null
                ? new PushMessageBuilder(_email, _password, _baseUrl)
                : new PushMessageBuilder(_apiKey, _baseUrl);
        }

        /// <summary>
        /// Отправка SMS-кода в номере входящего звонка (метод push_msg). Подробнее: https://lk.sms-prosto.ru/help.php?faq=66
        /// </summary>
        /// <returns></returns>
        public IAuthCallBuilder MakeAuthCall()
        {
            return _apiKey == null 
                ? new AuthCallBuilder(_email, _password, _baseUrl)
                : new AuthCallBuilder(_apiKey, _baseUrl);
        }

        /// <summary>
        /// Авторизация методом "Входящего звонка от абонента", вместо SMS кодов. (Метод wait_call).
        /// Необходимо настроить хук, на который будет приходить запрос, после звонка от пользователя.
        /// Подробнее: https://lk.sms-prosto.ru/help.php?faq=60
        /// </summary>
        /// <returns></returns>
        public IWaitCallBuilder WaitForCall()
        {
            return _apiKey == null
                ? new WaitCallBuilder(_email, _password, _baseUrl)
                : new WaitCallBuilder(_apiKey, _baseUrl);
        }

        /// <summary>
        /// Получение статусов отправленных SMS. Подробнее: https://lk.sms-prosto.ru/help.php?faq=60
        /// </summary>
        /// <param name="msgId">id sms, который Вы получили при успешной отправке SMS методом push_msg</param>
        /// <returns></returns>
        public IQuery<GetStatusResponse> GetStatus(int msgId)
        {
            return _apiKey == null
                ? new GetStatusQuery(msgId, _email, _password, _baseUrl)
                : new GetStatusQuery(msgId, _apiKey, _baseUrl);
        }

        /// <summary>
        /// Получение информации об остатке баланса (метод get_profile). Подробнее: https://lk.sms-prosto.ru/help.php?faq=51
        /// </summary>
        /// <returns></returns>
        public IQuery<GetProfileResponse> GetProfile()
        {
            return _apiKey == null
                ? new GetProfileQuery(_email, _password, _baseUrl)
                : new GetProfileQuery(_apiKey, _baseUrl);
        }
    }
}
