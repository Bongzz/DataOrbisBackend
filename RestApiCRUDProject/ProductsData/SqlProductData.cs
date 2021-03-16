using RestApiCRUDProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestApiCRUDProject.ProductsData
{
    public class SqlProductData : IProductsData
    {
        private ProductContext productContext;

        public SqlProductData(ProductContext productContext)
        {
            this.productContext = productContext;
        }

        public Product AddProduct(Product product)
        {
            try
            {
                productContext.Products.Add(product);
                productContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public void DeleteProduct(Product product)
        {
            try
            {
                productContext.Products.Remove(product);
                productContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Product EditProduct(Product product)
        {
            var existingProduct = productContext.Products.Find(product.ProductId);
            if(existingProduct != null)
            {
                try
                {
                    existingProduct.ProductCode = product.ProductCode;
                    existingProduct.ProductDescriptionOriginal = product.ProductDescriptionOriginal;
                    existingProduct.ProductDescription = product.ProductDescription;
                    existingProduct.ProductCategory = product.ProductCategory;
                    existingProduct.ProductStatus = product.ProductStatus;
                    existingProduct.ProductBarcode = product.ProductBarcode;
                    existingProduct.Rowchecksum = product.Rowchecksum;

                    productContext.Products.Update(existingProduct);
                    productContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }               
            }
          
            return product;
        }

        public Product GetProduct(int productId)
        {
            try
            {
                var product = productContext.Products.Find(productId);
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Product> GetProducts()
        { 
            try
            {
                return productContext.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
