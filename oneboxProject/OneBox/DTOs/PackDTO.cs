using OneBox.Enums;
using OneBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneBox.DTOs
{
    public class PackDTO
    {
        public int Id { get; set; }
        public string SenderPhone { get; set; }
        public string RecipientPhone { get; set; }
        public Size Size { get; set; }
        public DateTime ModifedAt { get; set; }
        public PackState State { get; set; }
        public PostBoxDTO PostBoxDTO { get; set; }
    }
}
