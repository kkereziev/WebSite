using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Clothes.Dress;
using ProjectShop.Pages.Cloathes.Blouses.PaginatedList;

namespace ProjectShop.Pages.Sizes.SizeOfDresses
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }
        public string SizeOfDressSort { get; set; }
        public string ModelIdSort { get; set; }
        public string DressIdSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<DressSize> DressSize { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            //DressSize = await _context.DressSize.Include(d => d.Model).ToListAsync();
            this.CurrentFilter = searchString;
            this.SizeOfDressSort = sortOrder == "SizeOfDress" ? "SizeOfDress_desc" : "SizeOfDress";
            this.ModelIdSort = sortOrder == "ModelId" ? "ModelId_desc" : "ModelId";
            this.DressIdSort = sortOrder == "DressId" ? "DressId_desc" : "DressId";
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
            IQueryable<DressSize> colorIQ = from a in _context.DressSize
                    .Include(b => b.Model
                    )
                    .Include(b => b.Model.Dress)
                                           select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                int number = int.Parse(searchString);
                colorIQ = colorIQ.Where(s => s.SizeOfDress == number);
            }

            switch (sortOrder)
            {
                case "SizeOfDress":
                    colorIQ = colorIQ.OrderBy(a => a.SizeOfDress);
                    break;
                case "SizeOfDress_desc":
                    colorIQ = colorIQ.OrderByDescending(a => a.SizeOfDress);
                    break;
                case "ModelId":
                    colorIQ = colorIQ.OrderBy(a => a.Model.Name);
                    break;
                case "ModelId_desc":
                    colorIQ = colorIQ.OrderByDescending(a => a.Model.Name);
                    break;
                case "DressId_desc":
                    colorIQ = colorIQ.OrderByDescending(a => a.Model.DressId);
                    break;
                case "DressId":
                    colorIQ = colorIQ.OrderBy(a => a.Model.DressId);
                    break;
            }

            int pageSize = 3;
            DressSize = await PaginatedList<DressSize>.CreateAsync(
                colorIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
