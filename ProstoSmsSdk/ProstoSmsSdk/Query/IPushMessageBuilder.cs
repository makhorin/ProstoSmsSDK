namespace ProstoSmsSdk.Query
{
    public interface IPushMessageBuilder
    {
        /// <summary>
        /// Отправка SMS (метод push_msg)
        /// </summary>
        /// <returns></returns>
        ISmsBuilder ToMobile();
        /// <summary>
        /// Отправка SMS Вконтакте (метод push_msg)
        /// </summary>
        /// <returns></returns>
        ICascadeSenderStep ToVK();
        /// <summary>
        /// Отправка SMS Telegram (метод push_msg)
        /// </summary>
        /// <returns></returns>
        ICascadeSenderStep ToTelegram();
        /// <summary>
        /// Отправка SMS WhatsApp (метод push_msg)
        /// </summary>
        /// <returns></returns>
        ICascadeSenderStep ToWhatsApp();
        /// <summary>
        /// Отправка SMS Viber (метод push_msg)
        /// </summary>
        /// <returns></returns>
        IViberMessageBuilder ToViber();
    }
}
