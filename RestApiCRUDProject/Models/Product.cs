using System.ComponentModel.DataAnnotations;

namespace RestApiCRUDProject.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescriptionOriginal { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public string ProductBarcode { get; set; }
        public string Rowchecksum { get; set; }
    }
}
