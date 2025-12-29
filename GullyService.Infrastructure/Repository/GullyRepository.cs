using GullyService.Domain.Entities;
using GullyService.Infrastructure.Persistence;

namespace GullyService.Infrastructure.Repository
{
    public class GullyRepository : IGullyRepository
    {
        private readonly GullyDbContext _context;
        public GullyRepository(GullyDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Gully gully)
        {
            await _context.Gullies.AddAsync(gully);
            await _context.SaveChangesAsync();
        }
    }
}
