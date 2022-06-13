namespace productManagementAPI.Repository.IRepository
{
    public interface IUnitOfWorkRepository
    {
        IUserRepository UserRep { get; }
        //ICategoryRepository CategoryRep { get; }
        //IShoppingCartRepository ShoppingCartRep { get; }
        //IOrderHeaderRepository OrderHeaderRep { get; }
        //IOrderDetailsRepository OrderDetailsRep { get; }
        void Save();
    }
}
