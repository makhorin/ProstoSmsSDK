using System;
using System.Runtime.Serialization;

namespace ProstoSmsSdk.Responses
{
    [DataContract]
    public class GetStatusResponse
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Отправитель с которым передалась SMS
        /// </summary>
        [DataMember(Name = "sender_name")]
        public string SenderName { get; set; }

        /// <summary>
        /// Текст отправленной смс
        /// </summary>
        [DataMember(Name = "text")]
        public string Text { get; set; }

        /// <summary>
        /// Номер Абонента
        /// </summary>
        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Тип сообщения ("0" - flash SMS, "1" - cтандартная SMS)
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Количество сегментов SMS
        /// </summary>
        [DataMember(Name = "n_raw_sms")]
        public string RawSms { get; set; }

        /// <summary>
        /// Время отправки SMS
        /// </summary>
        [DataMember(Name = "start_time")]
        public DateTime? SendTime { get; set; }

        /// <summary>
        /// Время доставки SMS абоненту
        /// </summary>
        [DataMember(Name = "last_update")]
        public DateTime? DeliveryTime { get; set; }

        /// <summary>
        /// id тарифной группы, как правило совпадает с id Оператора связи, список id можно запросить в Поддержке
        /// </summary>
        [DataMember(Name = "id_tarifs_group")]
        public string TarifsGroupId { get; set; }

        /// <summary>
        /// 1 - 'Доставлено', 2 - 'Не доставлено', 16 - 'Не доставлено в SMSC', 34 - 'Не доставлено (просрочено)', 0 - 'Отправлено'
        /// </summary>
        [DataMember(Name = "state")]
        public string State { get; set; }

        /// <summary>
        /// 'Доставлено', 'Не доставлено', 'Не доставлено в SMSC', 'Не доставлено (просрочено)', 'Отправлено'
        /// </summary>
        [DataMember(Name = "state_text")]
        public string StateText { get; set; }

        /// <summary>
        /// Стоимость одного сегмента
        /// </summary>
        [DataMember(Name = "credits")]
        public string Credits { get; set; }
    }
}
