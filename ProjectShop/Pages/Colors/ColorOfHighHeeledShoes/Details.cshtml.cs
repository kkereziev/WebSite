using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Shoes.HighHeeledShoes;

namespace ProjectShop.Pages.Colors.ColorOfHighHeeledShoes
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DetailsModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public HighHeeledShoesColors HighHeeledShoesColors { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HighHeeledShoesColors = await _context.HighHeeledShoesColors.FirstOrDefaultAsync(m => m.Id == id);

            if (HighHeeledShoesColors == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
