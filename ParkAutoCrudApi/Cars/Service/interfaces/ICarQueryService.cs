using ParkAutoCrudApi.Cars.Model;

namespace ParkAutoCrudApi.Cars.Service.interfaces
{
    public interface ICarQueryService
    {
        Task<IEnumerable<Car>> GetAllCar();
        Task<Car> GetByBrand(string brand);
        Task<Car> GetById(int id);
    }
}
