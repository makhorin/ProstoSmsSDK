namespace ProstoSmsSdk.Query
{
    public interface IViberMessageBuilder : ICascadeSenderStep
    {
        /// <summary>
        /// Добавляет картинку к сообщению
        /// </summary>
        /// <param name="imgUrl">Адрес картинки</param>
        /// <returns></returns>
        IViberMessageBuilder SetImage(string imgUrl);
        /// <summary>
        /// Добавляет кнопку в сообщение
        /// </summary>
        /// <param name="title">Текст на кнопке</param>
        /// <param name="url">Адрес, куда будет перенаправлен пользователь при нажатии на кнопку</param>
        /// <returns></returns>
        IViberMessageBuilder SetButton(string title, string url);
    }
}
