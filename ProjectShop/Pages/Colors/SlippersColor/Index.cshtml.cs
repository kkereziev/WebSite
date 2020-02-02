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
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public IList<ColorOfSlippers> ColorOfSlippers { get;set; }

        public async Task OnGetAsync()
        {
            ColorOfSlippers = await _context.ColorOfSlippers
                .Include(c => c.Slippers).ToListAsync();
        }
    }
}
