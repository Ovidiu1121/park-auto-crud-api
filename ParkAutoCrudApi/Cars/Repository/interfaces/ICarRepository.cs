using ParkAutoCrudApi.Cars.Model;
using ParkAutoCrudApi.Dto;

namespace ParkAutoCrudApi.Cars.Repository.interfaces
{
    public interface ICarRepository
    {
        Task<ListCarDto> GetAllAsync();
        Task<CarDto> GetByBrandAsync(string brand);
        Task<CarDto> GetByIdAsync(int id);
        Task<CarDto> CreateCar(CreateCarRequest request);
        Task<CarDto> UpdateCar(int id,UpdateCarRequest request);
        Task<CarDto> DeleteCarById(int id);
    }
}
