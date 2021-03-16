using RestApiCRUDProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestApiCRUDProject.ProductsData
{
    public class MockProductData : IProductsData
    {
        private List<Product> products = ProductHelper.ProductList();

        public Product AddProduct(Product product)
        {
            product.ProductId = products.Count + 1;
            products.Add(product);
            return product;
        }

        public void DeleteProduct(Product product)
        {
            products.Remove(product);
        }

        public Product EditProduct(Product product)
        {
            var existingProduct = products.SingleOrDefault(x => x.ProductId == product.ProductId);
            existingProduct.ProductCode = product.ProductCode;
            existingProduct.ProductDescriptionOriginal = product.ProductDescriptionOriginal;
            existingProduct.ProductDescription = product.ProductDescription;
            existingProduct.ProductCategory = product.ProductCategory;
            existingProduct.ProductStatus = product.ProductStatus;
            existingProduct.ProductBarcode = product.ProductBarcode;
            existingProduct.Rowchecksum = product.Rowchecksum;

            return existingProduct;
        }

        public Product GetProduct(int productId)
        {
            return products.SingleOrDefault(x => x.ProductId == productId);
        }

        public List<Product> GetProducts()
        {
            return products;
        }
    }
}
