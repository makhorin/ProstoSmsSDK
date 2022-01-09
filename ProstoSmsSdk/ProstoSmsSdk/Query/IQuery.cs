using System.Threading.Tasks;

namespace ProstoSmsSdk.Query
{
    public interface IQuery<T>
    {
        Task<T> ExecuteAsync();
    }
}
