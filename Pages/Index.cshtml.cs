using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab01.Models;

namespace Lab01.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public int Year { get; set; }

        public string? ZodiacSign { get; set; }

        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostGetZodiac()
        {
            // Validate year between 1900 and next year
            int nextYear = DateTime.Now.Year + 1;
            if (Year < 1900 || Year > nextYear)
            {
                ErrorMessage = $"Year must be between 1900 and {nextYear}. Please try again.";
                return Page();
            }

            ZodiacSign = Utils.GetZodiac(Year).ToLower(); // Convert to lowercase for image reference
            return Page();
        }

        public IActionResult OnPostClear()
        {
            Year = 0;
            ZodiacSign = null;
            ErrorMessage = null;
            return Page();
        }
    }
}
