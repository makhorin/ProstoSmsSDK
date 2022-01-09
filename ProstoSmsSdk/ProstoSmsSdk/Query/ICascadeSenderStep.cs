namespace ProstoSmsSdk.Query
{
    public interface ICascadeSenderStep : ITextStep
    {
        /// <summary>
        /// Отправка SMS методом каскадной маршрутизации
        /// </summary>
        /// <returns></returns>
        ICascadeSenderStep AndThenToMobile();
        /// <summary>
        /// Отправка SMS ВКонтакте методом каскадной маршрутизации
        /// </summary>
        /// <returns></returns>
        ICascadeSenderStep AndThenToVk();
        /// <summary>
        /// Отправка SMS WhatsApp методом каскадной маршрутизации
        /// </summary>
        /// <returns></returns>
        ICascadeSenderStep AndThenToWhatsApp();
        /// <summary>
        /// Отправка SMS Telegram методом каскадной маршрутизации
        /// </summary>
        /// <returns></returns>
        ICascadeSenderStep AndThenToTelegram();
        /// <summary>
        /// Отправка SMS Viber методом каскадной маршрутизации
        /// </summary>
        /// <returns></returns>
        ICascadeSenderStep AndThenToViber();
    }
}
