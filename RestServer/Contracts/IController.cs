using System.Threading.Tasks;

namespace RestServer.Contracts
{
    public interface IController<DBEntity> where DBEntity : class
    {
        void DeleteByID(int id);
        Task<DBEntity> GetByID(int id);
        void Post(object json);
        void Update(DBEntity entityToUpdate);
    }
}
