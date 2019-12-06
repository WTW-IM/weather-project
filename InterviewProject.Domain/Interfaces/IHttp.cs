using System.Threading.Tasks;

namespace InterviewProject.Domain.Interfaces
{
    public interface IHttp
    {
        Task<T> Get<T>(string url);
    }
}