using AppShopAPI.DTO;
using AppShopAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace AppShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly TestContext DBContext;

        public ItemsController(TestContext DBContext)
        {
            this.DBContext = DBContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemDTO>>> Get()
        {
            //  var List = await DBContext.Items.ToListAsync();

            var List = await DBContext.Items.Select(
                s => new ItemDTO(s)
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
        [HttpGet("{Id}")]
        public async Task<ActionResult<ItemDTO>> GetItemById(long Id)
        {
            // Item item = await DBContext.Items.FirstOrDefaultAsync(s => s.Id == Id);
            ItemDTO item = await DBContext.Items.Select(
                s => new ItemDTO(s)).FirstOrDefaultAsync(s => s.Id == Id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return item;
            }
        }

        [HttpGet("Categories")]
        public async Task<ActionResult<List<ItemCategoryDTO>>> GetItemsCategories()
        {
            List<ItemCategoryDTO> list = await DBContext.ProductCategory.Select(
                s => new ItemCategoryDTO(s)
                ).ToListAsync();
            if (list.Count > 0)
            {
                return list;
                // return Ok(List);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("ByProperty")]
        public async Task<ActionResult<List<ItemDTO>>> GetByProperty([FromQuery] bool? Stock,int Count)
        {
            //Get (Count) items where (stock) sorted by descending quanity
            List<ItemDTO> List = new List<ItemDTO>();
            if (Stock != null & Count > 0)
            {
                List = await DBContext.Items.Where(s => s.Stock == Stock).OrderByDescending(r => r.Quantity).Take(Count).Select(
               s => new ItemDTO(s)
               ).ToListAsync();
            }

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

        [HttpPost("InsertItem")]
        public async Task<HttpStatusCode> InsertItem(ItemDTO item)
        {
            var entity = new Item()
            {
                Name = item.Name,
                Description = item.Description,
                ProductType_id = item.ProductType_id,
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

            if (entity == null || entity.Id == null)
            { return HttpStatusCode.NotFound; }    

            entity.Name = item.Name;
            entity.Description = item.Description;
            entity.ProductType_id = item.ProductType_id;
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
        [HttpGet("Test")]
        public async Task<List<string[]>> Test()
        {
            List<string[]> list = new List<string[]>();

            string[] mass =
            {
                "Test1",
                "test2",
                "Tester3",
                "SecsTest4",
                "BigSirTest5"
            };
            string[] mass1 =
            {
                "Test6",
                "test7",
                "Tester8",
                "SecsTest9",
                "BigSirTest/10"
            };
            list.Add(mass1);
            list.Add(mass);
            return list;
        }
    }
}
