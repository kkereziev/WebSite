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

namespace ProjectShop.Pages.ModelsOfClothes.ModelsOfDress
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }
        public string NameSort { get; set; }
        public string DressIdSort { get; set; }

        public string CurrentFilter { get; set; }

        public string CurrentSort { get; set; }
        public PaginatedList<DressModel> DressModel { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            //DressModel = await _context.DressModel.Include(d => d.Dress).ToListAsync();
            this.CurrentFilter = searchString;
            this.NameSort = sortOrder == "Name" ? "Name_desc" : "Name";
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
            IQueryable<DressModel> modelIQ = from a in _context.DressModel
                    .Include(s => s.Dress)
                    .Include(s => s.Size)
                    .Include(c => c.Colors)
                select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                if (searchString.Length == 36)
                {
                    Guid number = Guid.Parse(searchString);
                    modelIQ = modelIQ.Where(a => a.DressId.Equals(number));
                }
                else
                {
                    modelIQ = modelIQ.Where(a => a.Name.Contains(searchString) || a.Dress.Brand.Contains(searchString));
                }
            }

            switch (sortOrder)
            {
                case "Name":
                    modelIQ = modelIQ.OrderBy(a => a.Name);
                    break;
                case "Name_desc":
                    modelIQ = modelIQ.OrderByDescending(a => a.Name);
                    break;
                case "DressId":
                    modelIQ = modelIQ.OrderBy(a => a.DressId);
                    break;
                case "DressId_desc":
                    modelIQ = modelIQ.OrderByDescending(a => a.DressId);
                    break;
            }

            int pageSize = 3;
            this.DressModel =
                await PaginatedList<DressModel>.CreateAsync(modelIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
