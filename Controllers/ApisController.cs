using Platform.Models;
using Platform.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApisController : ControllerBase
    {
        private readonly PlatformService _platformService;

        public ApisController(PlatformService platformService)
        {
            _platformService = platformService;
        }

        [HttpGet]
        public ActionResult<List<Api>> Get() =>
            _platformService.Get();

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<Api> Get(string id)
        {
            var platform = _platformService.Get(id);

            if (platform == null)
            {
                return NotFound();
            }

            return platform;
        }

        [HttpPost]
        public ActionResult<Api> Create(Api api)
        {
            _platformService.Create(api);

            return CreatedAtRoute("GetBook", new { id = api.Id.ToString() }, api);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Api apiIn)
        {
            var book = _platformService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _platformService.Update(id, apiIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _platformService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _platformService.Remove(book.Id);

            return NoContent();
        }
    }
}