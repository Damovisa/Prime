using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Prime.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Services.PrimeService _primeService;

        [BindProperty]
        public int Number { get; set; }
        public bool? IsPrime { get; set; }

        public IndexModel(ILogger<IndexModel> logger, Prime.Services.PrimeService primeService)
        {
            _logger = logger;
            _primeService = primeService;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost() {
            if (!ModelState.IsValid) {
                return Page();
            }

            IsPrime = _primeService.IsPrime(Number);
            return Page();
        }
    }
}
