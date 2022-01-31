using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using OneBox.Repositories;
using System;
using System.Threading.Tasks;

namespace OneBox.Pages
{
    public class ReceivePackageModel : PageModel
    {
        private IHostEnvironment _environment;
        private IPackRepository _packRepository;

        [BindProperty]
        public IFormFile Upload { get; set; }
        public int PackageId { get; set; } = 0;
        public string RecipientPhone { get; set; }
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

                // tutaj metoda pobierająca id paczki i zwracająca miejsce w paczkomacie (nr skrytki)

                var pack = _packRepository.GetPack(PackageId, RecipientPhone);
                var postBoxId = pack.PostBoxDTO.Id;
                PackageId = pack.Id;
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
