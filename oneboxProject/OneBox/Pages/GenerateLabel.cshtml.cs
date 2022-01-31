using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using OneBox.DTOs;
using OneBox.Enums;
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
        private IPackRepository _packRepository;

        public GenerateLabelModel(ILockerRepository lockerRepository, IPackRepository packRepository)
        {
            _lockerRepository = lockerRepository;
            _packRepository = packRepository;
        }

        public bool ShowMatches { get; set; } = false;
        public bool MatchError { get; set; } = false;
        public string FoundedCity { get; set; } = "";

        public List<LockerDTO> InputLocker { get; set; } = new List<LockerDTO>();
        public List<LockerDTO> FoundLockers { get; set; } = new List<LockerDTO>();
        public List<string> lockersToDisplay { get; set; } = new List<string>();

        public void OnGet() { }

        public void OnPostSearchPostBox(string postcode)
        {
            try
            {
                Regex postcodeRgx = new Regex(@"^([0-9]{2})(-[0-9]{3})?$");

                if (postcode != null && postcodeRgx.IsMatch(postcode))
                {
                    string uri = "http://kodpocztowy.intami.pl/api/" + postcode;

                    // Pobieranie danych z API          
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(uri);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.GetAsync(uri).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        var matchStreets = JsonConvert.DeserializeObject<IEnumerable<PostCodeApiVM>>(result);

                        foreach (var street in matchStreets)
                        {
                            InputLocker.Add(new LockerDTO
                            {
                                Postcode = postcode,
                                City = street.miejscowosc,
                                Street = street.ulica
                            });
                        }

                        FoundedCity = InputLocker.Select(x => x.City).FirstOrDefault();
                        FoundLockers = _lockerRepository.GetLockersOnStreets(InputLocker).ToList();
                        HashSet<string> existLockers = new HashSet<string>(FoundLockers.Select(s => s.Street));
                        var resultsLockers = InputLocker.Where(m => !existLockers.Contains(m.Street)).ToList();

                        foreach (var item in resultsLockers)
                        {
                            lockersToDisplay.Add(item.Street);
                        }

                        ShowMatches = true;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                MatchError = true;
            }
        }
        //dodano city i postcode
        //packsize zwróæ w postaci int 0 - S , 1 - M, 2 - L
        public void OnPostGenerate(string SelectedStreet, string postcode, string city, string StartNumber, string EndNumber, int packSize)
        {
            try
            {
                var locker = new LockerDTO() { City = city, Postcode = postcode, Street = SelectedStreet };
                var list = new List<LockerDTO>();
                list.Add(locker);
                var recipientLocker = _lockerRepository.GetLockersOnStreets(list).First();
                var lockerModel = _lockerRepository.GetParcelLocker(recipientLocker.Id);

                var packDTO = new PackDTO()
                {
                    RecipientPhone = EndNumber,
                    SenderPhone = StartNumber,
                    Size = (Size)packSize
                };
               
                // tutaj wkleiæ logikê zamawiania paczki, która zwraca Id paczki
                int packId = _packRepository.AddPack(packDTO, lockerModel);

                // przekierowanie na stronê tworz¹c¹ QR
                string createUrl = "http://localhost:9000/api/create/qr/" + packId;
                Redirect(createUrl);
            }
            catch (Exception) { }
            {
                Redirect(@"\");
            }
        }
    }
}
