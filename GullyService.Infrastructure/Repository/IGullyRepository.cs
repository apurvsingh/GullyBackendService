
using GullyService.Domain.Entities;

namespace GullyService.Infrastructure.Repository
{
    public interface IGullyRepository
    {
        Task AddAsync(Gully gully);
    }
}
