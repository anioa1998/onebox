using OneBox.Enums;
using System;

namespace OneBox.Models
{
    public class Pack
    {
        public int Id { get; set; }
        public string SenderPhone { get; set; }
        public string RecipientPhone { get; set; }
        public Size Size { get; set; }
        public DateTime ModifedAt { get; set; }
        public PackState State { get; set; }
        public ParcelLocker SenderParcel { get; set; }
        public ParcelLocker RecipientParcel { get; set; }
        public PostBox PostBox { get; set; }
        public Courier Courier { get; set; }
    }
}