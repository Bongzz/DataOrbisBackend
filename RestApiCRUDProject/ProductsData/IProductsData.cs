using RestApiCRUDProject.Models;
using System.Collections.Generic;

namespace RestApiCRUDProject.ProductsData
{
    public interface IProductsData
    {
        List<Product> GetProducts();

        Product GetProduct(int productId);

        Product AddProduct(Product product);

        void DeleteProduct(Product product);

        Product EditProduct(Product product);

    }
}
