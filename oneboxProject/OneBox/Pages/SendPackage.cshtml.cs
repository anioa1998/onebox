using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IronBarCode;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using OneBox.Repositories;

namespace OneBox.Pages
{
    public class SendPackageModel : PageModel
    {
        private IHostEnvironment _environment;
        private IPackRepository _packRepository;

        [BindProperty]
        public IFormFile Upload { get; set; }

        public int PackageId { get; set; } = 0;
        public bool ShowResult { get; set; } = false;
        public bool ShowError { get; set; } = false;

        public SendPackageModel(IHostEnvironment environment)
        {
            _environment = environment;
        }

        public void OnGet() { }

        public async Task OnPostAsync()
        {
            try
            {
                var filePath = Path.Combine(_environment.ContentRootPath, "uploads", Upload.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Upload.CopyToAsync(fileStream);
                }

                var qrPackCode = BarcodeReader.QuicklyReadOneBarcode(filePath, BarcodeEncoding.All, true);

                PackageId = _packRepository.GetPostBoxId(PackageId);
                ShowResult = true;
            } catch (Exception)
            {
                ShowResult = false;
                ShowError = true;
            }
        }
    }
}
