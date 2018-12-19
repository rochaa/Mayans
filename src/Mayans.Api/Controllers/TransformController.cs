using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mayans.Domain.Transforms;
using Microsoft.AspNetCore.Mvc;

namespace Mayans.Api.Controllers
{
    [Route("api/[controller]")]
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
            var transformDto = Mapper.Map<TransformDto>(transform);

            return Ok(transformDto);
        }
    }
}
