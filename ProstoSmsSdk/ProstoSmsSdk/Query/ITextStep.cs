namespace ProstoSmsSdk.Query
{
    public interface ITextStep
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">Текст сообщения</param>
        /// <returns></returns>
        IFromStep WithText(string text);
    }
}
