using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsAPI.Data;
using EventsAPI.Domain;
using EventsAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventContext _context;
        private readonly IConfiguration _config;
        public EventController(EventContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Items([FromQuery]int pageIndex = 0,
           [FromQuery] int pageSize = 6)
        {

            var items = await _context.EventDetails
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

            items = ChangePictureUrl(items);
            var itemsCount = await _context.EventDetails.LongCountAsync();
            var model = new PaginatedItemsViewModel<EventDetail>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Count = itemsCount,
                Data = items
            };
            return Ok(model);// 200 success 
        }

        private List<EventDetail> ChangePictureUrl(List<EventDetail> items)
        {
            items.ForEach(
                c => c.PictureUrl = c.PictureUrl.Replace("http://externalcatalogbaseurltobereplaced",
               _config["ExternalCatalogBaseUrl"]));
            return items;
        }
    }
}