
using RestSharp;

namespace Client.ConsumeAPI.APIClient
{
    public interface IAPIClientService<T> where T : class
    {
        Task<List<T>> GetAll(string subURL);
        Task<T> GetById(Int64 Id, string subURL);
        Task<RestResponse> Add(T model, string subURL);
        Task<RestResponse> Update(T model, string subURL);
        Task<RestResponse> Delete(Int64 Id, string subURL);
    }
}
