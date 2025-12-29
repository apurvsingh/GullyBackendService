namespace GullyService.Application.Dtos
{
    public class GullyResponse
    {
        public string Name { get; set; } = string.Empty;
        public int Height { get; set; }
        public int Width { get; set; }
        public int PipeHeight { get; set; }
        public int PipeDiameter { get; set; }
        public int WaterHeight { get; set; }
        public Error? Error { get; set; }
    }
}
