using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Shoes.HighHeeledShoes;

namespace ProjectShop.Pages.Sizes.SizeOfHighHeeledShoes
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DetailsModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public HighHeeledShoesSize HighHeeledShoesSize { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HighHeeledShoesSize = await _context.HighHeeledShoesSize
                .Include(h => h.Shoes).FirstOrDefaultAsync(m => m.Id == id);

            if (HighHeeledShoesSize == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
