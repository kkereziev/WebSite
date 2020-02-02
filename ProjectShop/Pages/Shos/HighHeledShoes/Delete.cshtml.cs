using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Shoes.HighHeeledShoes;

namespace ProjectShop.Pages.Shos.HighHeledShoes
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DeleteModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HighHeeledShoes HighHeeledShoes { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HighHeeledShoes = await _context.HighHeeledShoes.FirstOrDefaultAsync(m => m.Id == id);

            if (HighHeeledShoes == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HighHeeledShoes = await _context.HighHeeledShoes.FindAsync(id);

            if (HighHeeledShoes != null)
            {
                _context.HighHeeledShoes.Remove(HighHeeledShoes);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
