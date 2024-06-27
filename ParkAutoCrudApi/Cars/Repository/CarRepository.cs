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

        public async Task<CarDto> CreateCar(CreateCarRequest request)
        {
            var car = _mapper.Map<Car>(request);

            _context.Cars.Add(car);

            await _context.SaveChangesAsync();

            return _mapper.Map<CarDto>(car);

        }

        public async Task<CarDto> DeleteCarById(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            _context.Cars.Remove(car);

            await _context.SaveChangesAsync();

            return _mapper.Map<CarDto>(car);

        }

        public async Task<ListCarDto> GetAllAsync()
        {
            List<Car> result = await _context.Cars.ToListAsync();
            
            ListCarDto listCarDto = new ListCarDto()
            {
                carList = _mapper.Map<List<CarDto>>(result)
            };

            return listCarDto;
        }

        public async Task<CarDto> GetByBrandAsync(string brand)
        {
            var car = await _context.Cars.Where(c => c.Brand.Equals(brand)).FirstOrDefaultAsync();
            
            return _mapper.Map<CarDto>(car);
        }

        public async Task<CarDto> GetByIdAsync(int id)
        {
            var car = await _context.Cars.Where(c => c.Id == id).FirstOrDefaultAsync();
            
            return _mapper.Map<CarDto>(car);
        }

        public async Task<CarDto> UpdateCar(int id, UpdateCarRequest request)
        {
            var car = await _context.Cars.FindAsync(id);

            car.Brand=request.Brand??car.Brand;
            car.Price=request.Price??car.Price;
            car.Horse_power=request.Horse_power??car.Horse_power;
            car.Fabrication_year=request.Fabrication_year??car.Fabrication_year;

            _context.Cars.Update(car);

            await _context.SaveChangesAsync();

            return _mapper.Map<CarDto>(car);

        }
    }
}
