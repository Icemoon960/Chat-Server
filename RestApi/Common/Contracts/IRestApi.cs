using System.Net.Http;
using System.Threading.Tasks;

namespace RestApi.Contracts
{
    public interface IRestApi
    {
        Task<HttpResponseMessage> GetById(string path, int id, string token = "");
        Task<HttpResponseMessage> Get(string path, string token = "");
        Task<HttpResponseMessage> Put(string path, object model, string token = "");
        Task<HttpResponseMessage> Patch(string path, object model, string token = "");
        Task<HttpResponseMessage> Post(string path, object model, string token = "");
        Task<HttpResponseMessage> DeleteById(string path, int id, string token = "");
        Task<HttpResponseMessage> Delete(string path, string token = "");
    }
}
