using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace OneBox.Pages
{
    public class ReceivePackageModel : PageModel
    {
        private IHostEnvironment _environment;

        [BindProperty]
        public IFormFile Upload { get; set; }
        public int PackageId { get; set; } = 0;
        public bool ShowResult { get; set; } = false;
        public bool ShowError { get; set; } = false;

        public ReceivePackageModel(IHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task OnPostAsync()
        {
            try
            {
                //var filePath = Path.Combine(_environment.ContentRootPath, "uploads", Upload.FileName);
                //using (var fileStream = new FileStream(filePath, FileMode.Create))
                //{
                //    await Upload.CopyToAsync(fileStream);
                //}

                //var qrPackCode = BarcodeReader.QuicklyReadOneBarcode(filePath, BarcodeEncoding.All, true);

                // tutaj metoda pobieraj¹ca id paczki i zwracaj¹ca miejsce w paczkomacie (nr skrytki)

                PackageId = 40;
                ShowResult = true;
            }
            catch (Exception)
            {
                ShowResult = false;
                ShowError = true;
            }
        }
    }
}
