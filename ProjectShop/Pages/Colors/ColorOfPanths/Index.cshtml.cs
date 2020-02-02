using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Clothes.Panths;

namespace ProjectShop.Pages.Colors.ColorOfPanths
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public IList<PanthsColor> PanthsColor { get;set; }

        public async Task OnGetAsync()
        {
            PanthsColor = await _context.PanthsColor.ToListAsync();
        }
    }
}
