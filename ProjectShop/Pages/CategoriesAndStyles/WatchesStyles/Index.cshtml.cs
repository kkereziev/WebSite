using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Accessories.Watches;

namespace ProjectShop.Pages.CategoriesAndStyles.WatchesStyles
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public IList<StylesOfWatches> StylesOfWatches { get;set; }

        public async Task OnGetAsync()
        {
            StylesOfWatches = await _context.StylesOfWatches
                .Include(s => s.Watch).ToListAsync();
        }
    }
}
