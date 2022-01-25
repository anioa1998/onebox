using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using OneBox.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace OneBox.Pages
{
    public class GenerateLabelModel : PageModel
    {
        public bool ShowMatches { get; set; }
        public List<string> MatchAddress { get; set; } = new List<string>();

        public void OnGet()
        {
            ShowMatches = false;
        }

        public void OnPostSearchPostBox(string postcode)
        {
            Regex postcodeRgx = new Regex(@"^([0-9]{2})(-[0-9]{3})?$");

            if (postcodeRgx.IsMatch(postcode))
            {
                string uri = "http://kodpocztowy.intami.pl/api/" + postcode;

                try
                {
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
                            MatchAddress.Add(street.ulica);
                            // tutaj znalezenie paczkomatów do przypisanych ulic 
                        }

                        ShowMatches = true;
                    }
                }
                catch (Exception) { }
            }
        }
    }
}
