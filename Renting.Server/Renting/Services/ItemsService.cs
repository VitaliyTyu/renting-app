using Microsoft.EntityFrameworkCore;
using Renting.DAL.Entities;
using Renting.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Renting.Services
{
    public interface IItemsService
    {
        Task<List<Item>> GetItems(CancellationToken ct);
        Task<Item> CreateItem(Item item, CancellationToken ct);
        Task<Item> GetItem(int id, CancellationToken ct);
    }

    public class ItemsService : IItemsService
    {
        private readonly RentingDbContext _context;

        public ItemsService(RentingDbContext context)
        {
            _context = context;
        }


        public async Task<List<Item>> GetItems(CancellationToken ct)
        {
            return await _context.Items.ToListAsync(ct);
        }

        public async Task<Item> GetItem(int id, CancellationToken ct)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task<Item> CreateItem(Item item, CancellationToken ct)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync(ct);
            return item;
        }
    }
}
