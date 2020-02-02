using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Shoes.Sandals;

namespace ProjectShop.Pages.Colors.SandalsColor
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public IList<ColorOfSandals> ColorOfSandals { get;set; }

        public async Task OnGetAsync()
        {
            ColorOfSandals = await _context.ColorOfSandals
                .Include(c => c.Sandals).ToListAsync();
        }
    }
}
