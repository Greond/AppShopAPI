using AppShopAPI.Entities;
using System.Numerics;
namespace AppShopAPI.DTO
{
    public class ItemDTO
    {

        public ItemDTO(Item s)
        {
            //deep copy
            Id = s.Id;
            Name = s.Name;
            Description = s.Description;
            ProductType_id = s.ProductType_id;
            Price = s.Price;
            OldPrice = s.OldPrice;
            Stock = s.Stock;
            Icon = s.Icon;
            Stars = s.Stars;
            ReviewsCount = s.ReviewsCount;
            Quantity = s.Quantity;
            MainDescription = s.MainDescription;
            Specifications = s.Specifications;
        }
        public long Id { get; set; }

        /// <summary>
        /// Name of item
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Mini Description of item
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Type of item
        /// </summary>
        public long? ProductType_id { get; set; }

        /// <summary>
        /// Currect Price of item
        /// </summary>
        public int? Price { get; set; }

        /// <summary>
        /// Price of item without discount
        /// </summary>
        public int? OldPrice { get; set; }

        /// <summary>
        /// is item in stock
        /// </summary>
        public bool? Stock { get; set; }

        /// <summary>
        /// Icon of item not images
        /// </summary>
        public string? Icon { get; set; }

        /// <summary>
        /// stars count of item rating
        /// </summary>
        public sbyte Stars { get; set; }

        /// <summary>
        /// count of reviews for item
        /// </summary>
        public int? ReviewsCount { get; set; }

        /// <summary>
        /// how many count of item
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Full desciption of item
        /// </summary>
        public string? MainDescription { get; set; }

        /// <summary>
        /// Specifications of item
        /// </summary>
        public string? Specifications { get; set; }
    }
}
