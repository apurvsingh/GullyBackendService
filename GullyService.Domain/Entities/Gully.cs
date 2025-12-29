namespace GullyService.Domain.Entities
{
    public class Gully
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Height { get; set; }
        public int Width { get; set; }
        public int PipeHeight { get; set; }
        public int PipeDiameter { get; set; }
        public int WaterHeight { get; set; }
    }
}
