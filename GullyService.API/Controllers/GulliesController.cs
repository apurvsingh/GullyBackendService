using GullyService.Application.Dtos;
using GullyService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GullyService.API.Controllers
{
    [ApiController]
    [Route("api/v1/gullies")]
    public class GulliesController : ControllerBase
    {
        private readonly IGullyService _gullyService;

        public GulliesController(IGullyService gullyService)
        {
            _gullyService = gullyService;
        }

        // GET: api/gullies
        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    var products = await _gullyService.GetAllAsync();
        //    return Ok(products);
        //}


        // POST: api/gullies
        [HttpPost]
        public async Task<GullyResponse> Create([FromBody] GullyRequest request)
        {
            return await _gullyService.AddGullyAsync(request);
        }
    }
}
