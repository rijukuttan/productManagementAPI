

using productManagementAPI.Models;

namespace productManagementAPI.Repository.IRepository
{
    public interface IUserRepository:IRepository<User>
    {
        void Update(User User);
       // void Save();
       
    }
}
