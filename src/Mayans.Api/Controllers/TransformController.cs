using Mayans.Domain.Transforms;
using Microsoft.AspNetCore.Mvc;

namespace Mayans.Api.Controllers
{
    [Route("api/[controller]/Calculate")]
    [ApiController]
    public class TransformController : ControllerBase
    {
        private readonly TransformCalculate _transformCalculate;

        public TransformController(TransformCalculate transformCalculate)
        {
            _transformCalculate = transformCalculate;
        }

        [HttpPost]
        public IActionResult Post([FromBody] TransformDto _tranformDto)
        {
            var transform = _transformCalculate.Calculate(_tranformDto);
            var transformCalculateDto = new TransformCalculateDto { Result = transform.Result };
            return Ok(transformCalculateDto);
        }
    }
}
