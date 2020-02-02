using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Clothes.Panths;

namespace ProjectShop.Pages.Sizes.SizeOfPanths
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public IList<PanthsSize> PanthsSize { get;set; }

        public async Task OnGetAsync()
        {
            PanthsSize = await _context.PanthsSize
                .Include(p => p.Panths).ToListAsync();
        }
    }
}
