using GullyService.Application.Dtos;

namespace GullyService.Application.Interfaces
{
    public interface IGullyService
    {
        Task<GullyResponse> AddGullyAsync(GullyRequest gullyRequest);
    }
}
