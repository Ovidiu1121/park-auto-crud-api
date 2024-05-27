using AutoMapper;
using ParkAutoCrudApi.Cars.Model;
using ParkAutoCrudApi.Cars.Repository.interfaces;
using ParkAutoCrudApi.Data;
using ParkAutoCrudApi.Dto;
using Microsoft.EntityFrameworkCore;

namespace ParkAutoCrudApi.Cars.Repository
{
    public class CarRepository: ICarRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CarRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Car> CreateCar(CreateCarRequest request)
        {
            var car = _mapper.Map<Car>(request);

            _context.Cars.Add(car);

            await _context.SaveChangesAsync();

            return car;

        }

        public async Task<Car> DeleteCarById(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            _context.Cars.Remove(car);

            await _context.SaveChangesAsync();

            return car;

        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetByBrandAsync(string brand)
        {
            return await _context.Cars.FirstOrDefaultAsync(car => car.Brand.Equals(brand));
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await _context.Cars.FirstOrDefaultAsync(car => car.Id.Equals(id));
        }

        public async Task<Car> UpdateCar(int id, UpdateCarRequest request)
        {
            var car = await _context.Cars.FindAsync(id);

            car.Brand=request.Brand??car.Brand;
            car.Price=request.Price??car.Price;
            car.Horse_power=request.Horse_power??car.Horse_power;
            car.Fabrication_year=request.Fabrication_year??car.Fabrication_year;

            _context.Cars.Update(car);

            await _context.SaveChangesAsync();

            return car;

        }
    }
}
