using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Shoes.CasualShoes;

namespace ProjectShop.Pages.Sizes.CasualShoesSize
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DetailsModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public SizeOfCasualShoes SizeOfCasualShoes { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SizeOfCasualShoes = await _context.SizeOfCasualShoes
                .Include(s => s.Shoes).FirstOrDefaultAsync(m => m.Id == id);

            if (SizeOfCasualShoes == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
