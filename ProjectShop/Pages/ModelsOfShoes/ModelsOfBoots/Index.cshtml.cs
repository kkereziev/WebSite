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

namespace ProjectShop.Pages.ModelsOfShoes.ModelsOfBoots
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string BootsIdSort { get; set; }

        public string CurrentFilter { get; set; }

        public string CurrentSort { get; set; }
        public PaginatedList<BootsModel> BootsModel { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            //BootsModel = await _context.BootsModel.Include(b => b.Boots).ToListAsync();
            this.CurrentFilter = searchString;
            this.NameSort = sortOrder == "Name" ? "Name_desc" : "Name";
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
            IQueryable<BootsModel> modelIQ = from a in _context.BootsModel
                    .Include(s => s.Boots)
                    .Include(s => s.Size)
                    .Include(c => c.Colors)
                select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                if (searchString.Length == 36)
                {
                    Guid number = Guid.Parse(searchString);
                    modelIQ = modelIQ.Where(a => a.BootsId.Equals(number));
                }
                else
                {
                    modelIQ = modelIQ.Where(a => a.Name.Contains(searchString));
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
                case "BootsId":
                    modelIQ = modelIQ.OrderBy(a => a.BootsId);
                    break;
                case "BootsId_desc":
                    modelIQ = modelIQ.OrderByDescending(a => a.BootsId);
                    break;
            }

            int pageSize = 3;
            this.BootsModel =
                await PaginatedList<BootsModel>.CreateAsync(modelIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
