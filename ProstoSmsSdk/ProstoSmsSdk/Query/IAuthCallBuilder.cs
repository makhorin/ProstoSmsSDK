namespace ProstoSmsSdk.Query
{
    public interface IAuthCallBuilder
    {
        IFromStep WithCode(string code);
    }
}
