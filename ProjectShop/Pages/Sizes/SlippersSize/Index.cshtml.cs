using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Shoes.Slippers;

namespace ProjectShop.Pages.Sizes.SlippersSize
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public IList<SizeOfSlippers> SizeOfSlippers { get;set; }

        public async Task OnGetAsync()
        {
            SizeOfSlippers = await _context.SizeOfSlippers
                .Include(s => s.Slippers).ToListAsync();
        }
    }
}
