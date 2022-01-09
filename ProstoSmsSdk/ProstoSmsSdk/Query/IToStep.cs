namespace ProstoSmsSdk.Query
{
    public interface IToStep
    {
        /// <summary>
        /// Задаёт номер отправителя
        /// </summary>
        /// <param name="phoneNumber">В любом формате 7ХХХYYYххyy, 8ХХХYYYххyy, +7ХХХYYYххyy, 7(ХХХ)YYY-хх-yy и т.д.</param>
        IAdditionalOptionsStep To(string phoneNumber);
    }
}
