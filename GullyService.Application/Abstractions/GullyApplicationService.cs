using GullyService.Application.Dtos;
using GullyService.Application.Interfaces;
using GullyService.Domain.Entities;
using GullyService.Infrastructure.Repository;

namespace GullyService.Application.Abstractions
{
    public class GullyApplicationService : IGullyService
    {
        private readonly IGullyRepository _gullyRepository;

        public GullyApplicationService(IGullyRepository gullyRepository)
        {
            _gullyRepository = gullyRepository;
        }

        public async Task<GullyResponse> AddGullyAsync(GullyRequest gullyRequest)
        {
            var gullyEntity = new Gully
            {
                Id = Guid.NewGuid(),
                Name = gullyRequest.Name,
                Height = gullyRequest.Height,
                Width = gullyRequest.Width,
                PipeHeight = gullyRequest.PipeHeight,
                PipeDiameter = gullyRequest.PipeDiameter,
                WaterHeight = gullyRequest.WaterHeight
            };

            try
            {
                await _gullyRepository.AddAsync(gullyEntity);

                return new GullyResponse
                {
                    Name = gullyEntity.Name,
                    Height = gullyEntity.Height,
                    Width = gullyEntity.Width,
                    PipeHeight = gullyEntity.PipeHeight,
                    PipeDiameter = gullyEntity.PipeDiameter,
                    WaterHeight = gullyEntity.WaterHeight,
                };
            }
            catch (Exception ex) 
            {
                return new GullyResponse
                {
                    Error = new Error()
                    {
                        ErrorMessage = "Failed to save gully details",
                    }
                };
            }
        }
    }
}
