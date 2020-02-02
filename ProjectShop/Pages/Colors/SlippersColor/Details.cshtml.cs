using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Shoes.Slippers;

namespace ProjectShop.Pages.Colors.SlippersColor
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DetailsModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public ColorOfSlippers ColorOfSlippers { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ColorOfSlippers = await _context.ColorOfSlippers
                .Include(c => c.Slippers).FirstOrDefaultAsync(m => m.Id == id);

            if (ColorOfSlippers == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
