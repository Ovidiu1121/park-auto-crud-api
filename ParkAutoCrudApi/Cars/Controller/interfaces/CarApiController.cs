using Microsoft.AspNetCore.Mvc;
using ParkAutoCrudApi.Cars.Model;
using ParkAutoCrudApi.Dto;

namespace ParkAutoCrudApi.Cars.Controller.interfaces
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class CarApiController: ControllerBase
    {
        [HttpGet("all")]
        [ProducesResponseType(statusCode: 200, type: typeof(IEnumerable<Car>))]
        [ProducesResponseType(statusCode: 404, type: typeof(String))]
        public abstract Task<ActionResult<IEnumerable<Car>>> GetAll();

        [HttpPost("create")]
        [ProducesResponseType(statusCode: 201, type: typeof(Car))]
        [ProducesResponseType(statusCode: 400, type: typeof(String))]
        public abstract Task<ActionResult<Car>> CreateCar([FromBody] CreateCarRequest request);

        [HttpPut("update/{id}")]
        [ProducesResponseType(statusCode: 202, type: typeof(Car))]
        [ProducesResponseType(statusCode: 400, type: typeof(String))]
        [ProducesResponseType(statusCode: 404, type: typeof(String))]
        public abstract Task<ActionResult<Car>> UpdateCar([FromRoute] int id, [FromBody] UpdateCarRequest request);

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(statusCode: 202, type: typeof(Car))]
        [ProducesResponseType(statusCode: 404, type: typeof(String))]
        public abstract Task<ActionResult<Car>> DeleteCar([FromRoute] int id);

        [HttpGet("{brand}")]
        [ProducesResponseType(statusCode: 202, type: typeof(Car))]
        [ProducesResponseType(statusCode: 404, type: typeof(String))]
        public abstract Task<ActionResult<Car>> GetByBrandRoute([FromRoute] string brand);
    }
}
