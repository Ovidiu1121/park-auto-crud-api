using ParkAutoCrudApi.Cars.Model;
using ParkAutoCrudApi.Cars.Repository.interfaces;
using ParkAutoCrudApi.Cars.Service.interfaces;
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

        public async Task<IEnumerable<Car>> GetAllCar()
        {
            IEnumerable<Car> cars = await _repository.GetAllAsync();

            if (cars.Count().Equals(0))
            {
                throw new ItemDoesNotExist(Constants.NO_CAR_EXIST);
            }

            return cars;
        }

        public async Task<Car> GetByBrand(string brand)
        {
            Car car = await _repository.GetByBrandAsync(brand);

            if (car == null)
            {
                throw new ItemDoesNotExist(Constants.CAR_DOES_NOT_EXIST);
            }

            return car;
        }

        public async Task<Car> GetById(int id)
        {
            Car car = await _repository.GetByIdAsync(id);

            if (car == null)
            {
                throw new ItemDoesNotExist(Constants.CAR_DOES_NOT_EXIST);
            }

            return car;
        }
    }
}
