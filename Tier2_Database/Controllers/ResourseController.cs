using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simple_booking_system.Models;
using Tier2_Database.Services;

namespace Tier2_Database.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResourseController : ControllerBase
    {
        private IResourceService ResourceService;

        public ResourseController(IResourceService resourceService)
        {
            ResourceService = resourceService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Resource>>> GetResources()
        {
            try
            {
                IList<Resource> resources = await ResourceService.GetResources();
                return Ok(resources);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}