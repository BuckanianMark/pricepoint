

using System.ComponentModel.DataAnnotations;

namespace Core.Entities.OrderAggregate
{
    public class ProductItemOrdered
    {
        public ProductItemOrdered()
        {
        }

        public ProductItemOrdered(int productItemId,
        string productName,string pictureUrl)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            PictureUrl = pictureUrl;
        }
        [Key]
        public int ProductItemId{ get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
    }
}