namespace ProstoSmsSdk
{
    public enum Priority : byte
    {
        /// <summary>
        /// Только для СМС кодов и одиночных уведомлений требующих мгновенной доставки (например, "Ваша машина подана, выходите.", "Введите код: 2233");
        /// </summary>
        Asap = 1,
        /// <summary>
        /// Для быстрой доставки одиночных уведомлений (Например, "Вы записаны на прием на 15:00", "Вы отменили запись на прием");
        /// </summary>
        High,
        /// <summary>
        /// Прочие уведомления, которые рассылаются в цикле небольшому количеству абонентов (например, "Ваш заказ доставлен, не забудьте зайти на почту");
        /// </summary>
        General,
        /// <summary>
        /// Массовые рассылки (например, "У нас скидки, акции!!! Только до 31 января!").
        /// </summary>
        Bulk
    }
}
