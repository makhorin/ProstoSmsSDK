namespace ProstoSmsSdk.Query
{
    public interface IWaitCallBuilder
    {
        /// <summary>
        /// Задаёт номер телефона, с которого будет ожидаться звонок
        /// </summary>
        /// <param name="phoneNumber">В любом формате 7ХХХYYYххyy, 8ХХХYYYххyy, +7ХХХYYYххyy, 7(ХХХ)YYY-хх-yy и т.д.</param>
        IWaitPeriodStep From(string phoneNumber);
    }
}
