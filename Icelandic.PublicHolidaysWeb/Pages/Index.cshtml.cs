using System;
using Icelandic.PublicHolidays;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Icelandic.PublicHolidaysWeb.Pages
{
    public class IndexModel : PageModel
    {
        public int Year { get; set; }
        public int? Month { get; set; } = DateTime.Now.Month;

        public Dagar Dagar;

        public void OnGet(int? year, int? month)
        {
            Year = year ?? DateTime.Now.Year;
            Month = month;
            Dagar = new Dagar(Year);
        }

        public IActionResult OnPostGetYear(int year)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("/Index", new { year = year });
        }

        public IActionResult OnPostCalendar(int year, int month)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("/Index", new { year = year, month = month });
        }
    }
}
