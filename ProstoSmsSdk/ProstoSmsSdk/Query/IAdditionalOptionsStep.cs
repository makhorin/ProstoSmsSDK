using ProstoSmsSdk.Responses;

namespace ProstoSmsSdk.Query
{
    public interface IAdditionalOptionsStep : IQuery<PushMessageResponse>
    {
        /// <summary>
        /// Приоритет отправляемой СМС. Если будет не указан, по умолчанию присваивается priority=2.
        /// </summary>
        /// <returns></returns>
        IAdditionalOptionsStep WithPriority(Priority priority);

        /// <summary>
        /// Присваивает сообщению дополнительное свойство. При получении статусов доставки автоматическим способом, в параметре external_id будет передано Ваше значение. Используется для более удобной идетификации сообщения на Вашей стороне.
        /// </summary>
        /// <param name="externalId">Любое значение, id сообщения на Вашей стороне. Уникальность этих значений не проверяется на нашей стороне.</param>
        /// <returns></returns>
        IAdditionalOptionsStep WithExternalId(string externalId);
    }
}
