using System.Collections.Generic;

namespace OneBox.Models
{
    public class PostCodeApiVM
    {
        public string kod { get; set; }
        public string nazwa { get; set; }
        public string miejscowosc { get; set; }
        public string ulica { get; set; }
        public string gmina { get; set; }
        public string powiat { get; set; }
        public string wojewodztwo { get; set; }
        public string dzielnica { get; set; }
        public List<NumeringApiVM> numeracja { get; set; }
    }
}
