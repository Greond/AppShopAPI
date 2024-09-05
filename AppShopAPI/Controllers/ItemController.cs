using AppShopAPI.DTO;
using AppShopAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AppShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly TestContext DBContext;

        public ItemController(TestContext DBContext)
        {
            this.DBContext = DBContext;
        }

        [HttpGet("GetItems")]
        public async Task<ActionResult<List<ItemDTO>>> Get()
        {
          //  var List = await DBContext.Items.ToListAsync();

            var List = await DBContext.Items.Select(
                s => new ItemDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    ProductType = s.ProductType,
                    Price = s.Price,
                    OldPrice = s.OldPrice,
                    Stock = s.Stock,
                    Icon = s.Icon,
                    Stars = s.Stars,
                    ReviewsCount = s.ReviewsCount,
                    Quantity = s.Quantity,
                    MainDescription = s.MainDescription,
                    Specifications = s.Specifications
                }
                ).ToListAsync();

            if (List.Count > 0)
            {
                return List;
               // return Ok(List);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("GetItemById")]
        public async Task<ActionResult<ItemDTO>> GetItemById(long Id)
        {
            // Item item = await DBContext.Items.SingleOrDefaultAsync(s => s.Id == Id);
            ItemDTO item = await DBContext.Items.Select(
                s => new ItemDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    ProductType = s.ProductType,
                    Price = s.Price,
                    OldPrice = s.OldPrice,
                    Stock = s.Stock,
                    Icon = s.Icon,
                    Stars = s.Stars,
                    ReviewsCount = s.ReviewsCount,
                    Quantity = s.Quantity,
                    MainDescription = s.MainDescription,
                    Specifications = s.Specifications
                }).FirstOrDefaultAsync(s => s.Id == Id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return item;
            }
        }
        [HttpPost("InsertItem")]
        public async Task<HttpStatusCode> InsertItem(ItemDTO item)
        {
            var entity = new Item()
            {
                Name = item.Name,
                Description = item.Description,
                ProductType = item.ProductType,
                Price = item.Price,
                OldPrice = item.OldPrice,
                Stock = item.Stock,
                Icon = item.Icon,
                Stars = item.Stars,
                ReviewsCount = item.ReviewsCount,
                Quantity = item.Quantity,
                MainDescription = item.MainDescription,
                Specifications = item.Specifications
            };
            DBContext.Items.Add(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        [HttpPut("UpdateItem")]
        public async Task<HttpStatusCode> UpdateItem(ItemDTO item)
        {
            var entity = await DBContext.Items.FirstOrDefaultAsync(s => s.Id == item.Id);

            entity.Name = item.Name;
            entity.Description = item.Description;
            entity.ProductType = item.ProductType;
            entity.Price = item.Price;
            entity.OldPrice = item.OldPrice;
            entity.Stock = item.Stock;    
            entity.Icon = item.Icon;
            entity.Stars = item.Stars;
            entity.ReviewsCount = item.ReviewsCount;
            entity.Quantity = item.Quantity;
            entity.MainDescription = item.MainDescription;
            entity.Specifications = item.Specifications;

            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        [HttpDelete("DeleteItem")]
        public async Task<HttpStatusCode> Deleteitem(long Id)
        {
            var entity = new Item()
            {
                Id = Id
            };
            DBContext.Attach(entity);
            DBContext.Remove(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
