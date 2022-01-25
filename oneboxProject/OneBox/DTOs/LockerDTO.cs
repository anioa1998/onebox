using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneBox.DTOs
{
    public class LockerDTO
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string ParcelNumber { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
    }
}
