using AppShopAPI.Entities;

namespace AppShopAPI.DTO
{
    public class ItemCategoryDTO
    {
        public ItemCategoryDTO(ItemCategory s)
        {
            Id = s.Id;
            Name = s.Name;
            Description = s.Description;
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
