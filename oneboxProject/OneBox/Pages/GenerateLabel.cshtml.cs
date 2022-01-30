using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OneBox.DTOs;
using OneBox.Models;
using OneBox.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace OneBox.Pages
{
    public class GenerateLabelModel : PageModel
    {
        private ILockerRepository _lockerRepository;

        public GenerateLabelModel(ILockerRepository lockerRepository)
        {
            _lockerRepository = lockerRepository;
        }

        public bool ShowMatches { get; set; } = false;
        public bool MatchError { get; set; } = false;
        public List<LockerDTO> InputLocker { get; set; } = new List<LockerDTO>();
        public List<LockerDTO> FoundLockers { get; set; } = new List<LockerDTO>();

        public void OnGet() { }

        public void OnPostSearchPostBox(string postcode)
        {
            Regex postcodeRgx = new Regex(@"^([0-9]{2})(-[0-9]{3})?$");

            if (postcodeRgx.IsMatch(postcode))
            {
                string uri = "http://kodpocztowy.intami.pl/api/" + postcode;

                try
                {
                    // Pobieranie danych z API          
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(uri);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.GetAsync(uri).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        var matchStreets = JsonConvert.DeserializeObject<IEnumerable<PostCodeApiVM>>(result);

                        foreach(var street in matchStreets)
                        {
                            InputLocker.Add(new LockerDTO
                            {
                                Postcode = postcode,
                                City = street.miejscowosc,
                                Street = street.ulica
                            });
                        }
                        FoundLockers = _lockerRepository.GetLockersOnStreets(InputLocker).ToList();
                        HashSet<string> existLockers = new HashSet<string>(FoundLockers.Select(s => s.Street));
                        var results = InputLocker.Where(m => !existLockers.Contains(m.Street)).ToList();

                        ShowMatches = true;
                    }
                }
                catch (Exception) 
                {
                    MatchError = true;
                }
            }
        }

        public void OnPostGenerate(string SelectedStreet)
        {
            string x = "dwdw";
        }
    }
}
