namespace ProstoSmsSdk.Query
{
    public interface IFromStep
    {
        /// <summary>
        /// Задаёт имя отправителя
        /// </summary>
        /// <param name="senderName">Имя отправителя, максимальная длина 11 символов. Требования к отправителю: https://lk.sms-prosto.ru/help.php?faq=12
        /// Также не забудьте согласовать свой отправитель с Мегафон и МТС, подробнее тут: https://lk.sms-prosto.ru/help.php?faq=41 </param>
        IToStep From(string senderName);
    }
}
