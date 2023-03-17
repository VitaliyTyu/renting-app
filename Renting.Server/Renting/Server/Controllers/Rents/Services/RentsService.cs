using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using Lab9.App.DAL;

using Microsoft.EntityFrameworkCore;

using Renting.Server.Dtos;

namespace Renting.Server.Controllers.Rents.Services
{
    public interface IRentsService
    {
        Task<RentDto> GetRent(int id, CancellationToken ct);
        Task<List<RentDto>> GetRents(CancellationToken ct);
    }

    public class RentsService : IRentsService
    {
        private readonly RentingDbContext _context;
        private readonly IMapper _mapper;

        public RentsService(RentingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RentDto> GetRent(int id, CancellationToken ct)
        {
            var rent = await _context.Rents
                .Include(x => x.Item).ThenInclude(x => x.CountryOfOrigin)
                .Include(x => x.Item).ThenInclude(x => x.Warehouse)
                .Include(x => x.Item).ThenInclude(x => x.Category)
                .Include(x => x.Customer).ThenInclude(x => x.Discounts)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (rent == null)
                throw new ArgumentException("�� ������");

            return _mapper.Map<RentDto>(rent);
        }

        public async Task<List<RentDto>> GetRents(CancellationToken ct)
        {
            var rents = await _context.Rents
                .Include(x => x.Item).ThenInclude(x => x.CountryOfOrigin)
                .Include(x => x.Item).ThenInclude(x => x.Warehouse)
                .Include(x => x.Item).ThenInclude(x => x.Category)
                .Include(x => x.Customer).ThenInclude(x => x.Discounts)
                .Include(x => x.User)
                .ToListAsync();
            
            return _mapper.Map<List<RentDto>>(rents);
        }
    }
}
