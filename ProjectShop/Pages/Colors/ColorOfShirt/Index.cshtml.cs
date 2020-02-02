using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Clothes.Shirt;

namespace ProjectShop.Pages.Colors.ColorOfShirt
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public IList<ShirtColor> ShirtColor { get;set; }

        public async Task OnGetAsync()
        {
            ShirtColor = await _context.ShirtColor
                .Include(s => s.Shirt).ToListAsync();
        }
    }
}
