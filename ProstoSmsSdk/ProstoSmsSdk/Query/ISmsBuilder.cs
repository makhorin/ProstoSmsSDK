namespace ProstoSmsSdk.Query
{
    public interface ISmsBuilder : ITextStep
    {
        /// <summary>
        /// Платформа ожидает входящий вызов от указанного абонента в соответствии с значением параметра waitTime. Подробности: https://lk.sms-prosto.ru/help.php?faq=59
        /// </summary>
        /// <param name="waitTime">Время ожидания звонка. Допустимые значения от 60 до 300, секунды</param>
        /// <returns></returns>
        ISmsBuilder WithCallProtection(ushort waitTime);
    }
}
