using ProstoSmsSdk.Responses;

namespace ProstoSmsSdk.Query
{
    public interface IWaitPeriodStep
    {
        /// <summary>
        /// Платформа ожидает входящий вызов от указанного абонента в соответствии с значением параметра waitTime. Подробности: https://lk.sms-prosto.ru/help.php?faq=60
        /// </summary>
        /// <param name="waitTime">Время ожидания звонка. Допустимые значения от 60 до 300, секунды</param>
        /// <returns></returns>
        IQuery<WaitCallResponse> WaitFor(ushort waitTime);
    }
}
