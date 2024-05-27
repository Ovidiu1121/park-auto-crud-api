using ParkAutoCrudApi.Cars.Model;
using ParkAutoCrudApi.Dto;

namespace ParkAutoCrudApi.Cars.Service.interfaces
{
    public interface ICarCommandService
    {
        Task<Car> CreateCar(CreateCarRequest request);
        Task<Car> UpdateCar(int id, UpdateCarRequest request);
        Task<Car> DeleteCar(int id);
    }
}
