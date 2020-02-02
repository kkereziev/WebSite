using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectShop.Data;
using ProjectShop.Models.Shoes.CasualShoes;

namespace ProjectShop.Pages.Sizes.CasualShoesSize
{
    public class CreateModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public CreateModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ShoesId"] = new SelectList(_context.CasualShoes, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public SizeOfCasualShoes SizeOfCasualShoes { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SizeOfCasualShoes.Add(SizeOfCasualShoes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
