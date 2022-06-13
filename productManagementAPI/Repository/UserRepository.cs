
using productManagementAPI.Data;
using productManagementAPI.Models;
using productManagementAPI.Repository.IRepository;

//using CoreCodeFirst.Repository.IRepository;
using System.Linq.Expressions;

namespace productManagementAPI.Repository
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        private readonly DatabaseContext _db;

        public UserRepository(DatabaseContext db) : base(db)
        {
            _db = db;
        }
        /*     public void Save()
             {
                 _db.SaveChanges();
             }*/

        public void Update(User user)
        {
           _db.Update(user);
        }

       
    }
}
