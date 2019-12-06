using System.Threading.Tasks;

namespace InterviewProject.Interfaces {
    public interface IHttp
    {
        Task<T> Get<T>(string url);
    }
}