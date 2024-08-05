using webapi.productsproject.Context;
using webapi.productsproject.Domains;
using webapi.productsproject.Interfaces;

namespace webapi.productsproject.Repositories
{
    public class ProductsRepository : IProducts
    {
        private readonly ProductsContext _context;

        public ProductsRepository()
        {
            _context = new ProductsContext();
        }

        public void Delete(Guid ID)
        {
            try
            {
                Products searchedProduct = _context.Products.FirstOrDefault(p => p.IDProduct == ID)!;

                if (searchedProduct != null)
                {
                    _context.Products.Remove(searchedProduct);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Products> Get()
        {
            try
            {
                return _context.Products
                .Select(p => new Products
                {
                    IDProduct = p.IDProduct,
                    Name = p.Name,
                    Price = p.Price

                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Products GetByID(Guid ID)
        {
            try
            {

                Products searchedProduct = _context.Products.Select(p => new Products
                {
                    IDProduct = p.IDProduct,
                    Name = p.Name,
                    Price = p.Price

                }).FirstOrDefault(g => g.IDProduct == ID)!;

                return searchedProduct;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Post(Products product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Put(Guid ID, Products product)
        {
            try
            {
                Products searchedProduct = _context.Products.Find(ID)!;

                if (searchedProduct != null)
                {
                    searchedProduct.Name = product.Name;
                    searchedProduct.Price = product.Price;

                }

                _context.Products.Update(searchedProduct!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
