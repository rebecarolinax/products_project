using webapi.productsproject.Domains;

namespace webapi.productsproject.Interfaces
{
    public interface IProducts
    {
        void Delete(Guid ID);
        List<Products> Get();
        Products GetByID(Guid ID);
        void Post(Products product);

        void Put(Guid ID, Products product);
    }
}
