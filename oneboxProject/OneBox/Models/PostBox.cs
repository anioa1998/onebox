using OneBox.Enums;

namespace OneBox.Models
{
    public class PostBox //skrytka
    {
        public int Id { get; set; }
        public Size Size { get; set; }
        public PostBoxState State { get; set; }
        public ParcelLocker ParcelLocker { get; set; }
    }
}