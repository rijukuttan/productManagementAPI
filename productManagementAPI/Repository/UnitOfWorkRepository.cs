using productManagementAPI.Data;
using productManagementAPI.Repository.IRepository;

namespace productManagementAPI.Repository
{
    public class UnitOfWorkRepository:IUnitOfWorkRepository
    {
        private readonly DatabaseContext _db;
        public IUserRepository UserRep { get; private set; }
        //public ICategoryRepository CategoryRep { get; private set; }
        //public IShoppingCartRepository ShoppingCartRep { get; private set; }
        //public IOrderDetailsRepository OrderDetailsRep { get;}
        //public IOrderHeaderRepository OrderHeaderRep { get;}
        // public IProductRepository ProductRepository => throw new NotImplementedException();
        public UnitOfWorkRepository(DatabaseContext db)
        {
            _db = db;
            UserRep = new UserRepository(_db);
            //CategoryRep = new CategoryRepository(_db);
            //ShoppingCartRep = new ShoppingCartRepository(_db);
            //OrderDetailsRep = new OrderDetailsRepository(_db);
            //OrderHeaderRep = new OrderHeaderRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
