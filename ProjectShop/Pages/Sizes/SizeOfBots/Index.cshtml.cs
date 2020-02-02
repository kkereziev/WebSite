using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Shoes.Boots;
using ProjectShop.Pages.Cloathes.Blouses.PaginatedList;

namespace ProjectShop.Pages.Sizes.SizeOfBots
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }
        public string SizeOfBootsSort { get; set; }
        public string ModelIdSort { get; set; }
        public string BootsIdSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<SizeOfBoots> SizeOfBoots { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            // SizeOfBoots = await _context.SizeOfBoots.Include(s => s.Model).ToListAsync();
            this.CurrentFilter = searchString;
            this.SizeOfBootsSort = sortOrder == "SizeOfBoot" ? "SizeOfBoot_desc" : "SizeOfBoot";
            this.ModelIdSort = sortOrder == "ModelId" ? "ModelId_desc" : "ModelId";
            this.BootsIdSort = sortOrder == "BootsId" ? "BootsId_desc" : "BootsId";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            this.CurrentSort = sortOrder;
            this.CurrentFilter = searchString;
            IQueryable<SizeOfBoots> colorIQ = from a in _context.SizeOfBoots
                    .Include(b => b.Model)
                    .Include(b => b.Model.Boots)
                                           select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                int number = int.Parse(searchString);
                colorIQ = colorIQ.Where(s => s.SizeOfBoot == number);
            }

            switch (sortOrder)
            {
                case "SizeOfBoot":
                    colorIQ = colorIQ.OrderBy(a => a.SizeOfBoot);
                    break;
                case "SizeOfBoot_desc":
                    colorIQ = colorIQ.OrderByDescending(a => a.SizeOfBoot);
                    break;
                case "ModelId":
                    colorIQ = colorIQ.OrderBy(a => a.Model.Name);
                    break;
                case "ModelId_desc":
                    colorIQ = colorIQ.OrderByDescending(a => a.Model.Name);
                    break;
                case "CoatId_desc":
                    colorIQ = colorIQ.OrderByDescending(a => a.Model.BootsId);
                    break;
                case "CoatId":
                    colorIQ = colorIQ.OrderBy(a => a.Model.BootsId);
                    break;
            }

            int pageSize = 3;
            SizeOfBoots = await PaginatedList<SizeOfBoots>.CreateAsync(
                colorIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
