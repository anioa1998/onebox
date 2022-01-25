using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneBox.DTOs
{
    public class StreetsLockerDTO
    {
        public List<string> Streets { get; set; }
        public string City { get; set; }
        public string SelectedVendor { get; set; }
    }
}
