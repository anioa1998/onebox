using OneBox.Enums;

namespace OneBox.DTOs
{
    public class PostBoxDTO
    {
        public int Id { get; set; }
        public Size Size { get; set; }
        public PostBoxState State { get; set; }
    }
}
