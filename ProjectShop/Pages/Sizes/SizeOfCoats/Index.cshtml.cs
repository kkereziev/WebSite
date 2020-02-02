using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Clothes.Blouse;
using ProjectShop.Models.Clothes.Coat;
using ProjectShop.Pages.Cloathes.Blouses.PaginatedList;

namespace ProjectShop.Pages.Sizes.SizeOfCoats
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }
        public string SizeOfCoatSort { get; set; }
        public string ModelIdSort { get; set; }
        public string CoatIdSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<CoatSize> CoatSize { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            //CoatSize = await _context.CoatSize.ToListAsync();
            this.CurrentFilter = searchString;
            this.SizeOfCoatSort = sortOrder == "SizeOfCoat" ? "SizeOfCoat_desc" : "SizeOfCoat";
            this.ModelIdSort = sortOrder == "ModelId" ? "ModelId_desc" : "ModelId";
            this.CoatIdSort = sortOrder == "CoatId" ? "CoatId_desc" : "CoatId";
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
            IQueryable<CoatSize> colorIQ = from a in _context.CoatSize
                    .Include(b => b.Model)
                    .Include(b => b.Model.Coat)
                                             select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                int number = int.Parse(searchString);
                colorIQ = colorIQ.Where(s => s.SizeOfCoat == number);
            }

            switch (sortOrder)
            {
                case "SizeOfCoat":
                    colorIQ = colorIQ.OrderBy(a => a.SizeOfCoat);
                    break;
                case "SizeOfCoat_desc":
                    colorIQ = colorIQ.OrderByDescending(a => a.SizeOfCoat);
                    break;
                case "ModelId":
                    colorIQ = colorIQ.OrderBy(a => a.Model.Name);
                    break;
                case "ModelId_desc":
                    colorIQ = colorIQ.OrderByDescending(a => a.Model.Name);
                    break;
                case "CoatId_desc":
                    colorIQ = colorIQ.OrderByDescending(a => a.Model.CoatId);
                    break;
                case "CoatId":
                    colorIQ = colorIQ.OrderBy(a => a.Model.CoatId);
                    break;
            }

            int pageSize = 3;
            CoatSize = await PaginatedList<CoatSize>.CreateAsync(
                colorIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
