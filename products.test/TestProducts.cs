using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.productsproject.Domains;
using webapi.productsproject.Interfaces;
using webapi.productsproject.Repositories;

namespace products.test
{
    public class TestProducts
    {
        [Fact]
        public void Get()
        {
            List<Products> productsList = new List<Products>
            {
                new Products { IDProduct = Guid.NewGuid(), Name = "Product 1", Price = 56 },
                new Products { IDProduct = Guid.NewGuid(), Name = "Product 2", Price = 12 },
                new Products { IDProduct = Guid.NewGuid(), Name = "Product 3", Price = 37 }
            };

            var mockRepository = new Mock<IProducts>();

            mockRepository.Setup(x => x.Get()).Returns(productsList);

            var result = mockRepository.Object.Get();

            Assert.Equal(3, result.Count);
        }


        [Fact]
        public void Post()
        {
            Products product = new Products { IDProduct = Guid.NewGuid(), Name = "Product 4", Price = 100 };

            List<Products> productsList = new List<Products>();

            var mockRepository = new Mock<IProducts>();

            mockRepository.Setup(x => x.Post(It.IsAny<Products>())).Callback<Products>(x => productsList.Add(x));

            mockRepository.Object.Post(product);


            Assert.Contains(product, productsList);

        }

        [Fact]
        public void Delete()
        {
            Products productsToDelete = new Products
            {
                IDProduct = Guid.NewGuid(),
                Name = "Product 5",
                Price = 100
            };

            List<Products> productsList = new List<Products> { productsToDelete };

            var mockRepository = new Mock<IProducts>();

            mockRepository.Setup(x => x.Delete(It.IsAny<Guid>()))
                          .Callback<Guid>(ID => productsList.RemoveAll(p => p.IDProduct == ID));

            mockRepository.Object.Delete(productsToDelete.IDProduct);
        }

        [Fact]
        public void GetByID()
        {
            Products productsExpected = new Products
            {
                IDProduct = Guid.NewGuid(),
                Name = "Product 6",
                Price = 1245
            };

            List<Products> productsList = new List<Products> { productsExpected };

            var mockRepository = new Mock<IProducts>();

            mockRepository.Setup(x => x.GetByID(It.IsAny<Guid>())).Returns(productsExpected);

            mockRepository.Object.GetByID(productsExpected.IDProduct);
        }

        [Fact]
        public void Update()
        {
            Products originalProducts = new Products
            {
                IDProduct = Guid.NewGuid(),
                Name = "Product 7",
                Price = 50
            };

            Products updatedProduct = new Products
            {
                IDProduct = Guid.NewGuid(),
                Name = "Product 8",
                Price = 60
            };


            var mockRepository = new Mock<IProducts>();

            mockRepository.Setup(x => x.Put(originalProducts)).Callback((p) =>
            {
                p.Name = updatedProduct.Name;
                p.Price = updatedProduct.Price;
            });

            mockRepository.Object.Put(originalProducts);


            Assert.Equal(updatedProduct.Name, originalProducts.Name);
            Assert.Equal(updatedProduct.Price, originalProducts.Price);
        }
    }


}

