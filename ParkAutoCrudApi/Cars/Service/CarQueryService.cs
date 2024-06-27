using ParkAutoCrudApi.Cars.Model;
using ParkAutoCrudApi.Cars.Repository.interfaces;
using ParkAutoCrudApi.Cars.Service.interfaces;
using ParkAutoCrudApi.Dto;
using ParkAutoCrudApi.System.Constant;
using ParkAutoCrudApi.System.Exceptions;

namespace ParkAutoCrudApi.Cars.Service
{
    public class CarQueryService: ICarQueryService
    {
        private ICarRepository _repository;

        public CarQueryService(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<ListCarDto> GetAllCar()
        {
            ListCarDto cars = await _repository.GetAllAsync();

            if (cars.carList.Count().Equals(0))
            {
                throw new ItemDoesNotExist(Constants.NO_CAR_EXIST);
            }

            return cars;
        }

        public async Task<CarDto> GetByBrand(string brand)
        {
            CarDto car = await _repository.GetByBrandAsync(brand);

            if (car == null)
            {
                throw new ItemDoesNotExist(Constants.CAR_DOES_NOT_EXIST);
            }

            return car;
        }

        public async Task<CarDto> GetById(int id)
        {
            CarDto car = await _repository.GetByIdAsync(id);

            if (car == null)
            {
                throw new ItemDoesNotExist(Constants.CAR_DOES_NOT_EXIST);
            }

            return car;
        }
    }
}
