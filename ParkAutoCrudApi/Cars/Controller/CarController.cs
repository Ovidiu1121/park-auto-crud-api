using Microsoft.AspNetCore.Mvc;
using ParkAutoCrudApi.Cars.Controller.interfaces;
using ParkAutoCrudApi.Cars.Model;
using ParkAutoCrudApi.Cars.Service.interfaces;
using ParkAutoCrudApi.Dto;
using ParkAutoCrudApi.System.Exceptions;

namespace ParkAutoCrudApi.Cars.Controller
{
    public class CarController: CarApiController
    {
        private ICarCommandService _carCommandService;
        private ICarQueryService _carQueryService;

        public CarController(ICarCommandService carCommandService, ICarQueryService carQueryService)
        {
            _carCommandService = carCommandService;
            _carQueryService = carQueryService;
        }

        public override async Task<ActionResult<CarDto>> CreateCar([FromBody] CreateCarRequest request)
        {
            try
            {
                var cars = await _carCommandService.CreateCar(request);

                return Created("Masina a fost adaugata",cars);
            }
            catch (ItemAlreadyExists ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public override async Task<ActionResult<CarDto>> DeleteCar([FromRoute] int id)
        {
            try
            {
                var cars = await _carCommandService.DeleteCar(id);

                return Accepted("", cars);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<ListCarDto>> GetAll()
        {
            try
            {
                var cars = await _carQueryService.GetAllCar();
                return Ok(cars);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<CarDto>> GetByBrandRoute([FromRoute] string brand)
        {
            try
            {
                var cars = await _carQueryService.GetByBrand(brand);
                return Ok(cars);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<CarDto>> GetByIdRoute(int id)
        {
            try
            {
                var cars = await _carQueryService.GetById(id);
                return Ok(cars);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<CarDto>> UpdateCar([FromRoute]int id, [FromBody] UpdateCarRequest request)
        {
            try
            {
                var cars = await _carCommandService.UpdateCar(id,request);

                return Ok(cars);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
