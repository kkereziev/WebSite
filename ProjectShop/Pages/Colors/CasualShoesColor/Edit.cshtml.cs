using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Shoes.CasualShoes;

namespace ProjectShop.Pages.Colors.CasualShoesColor
{
    public class EditModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public EditModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ColorOfCasualShoes ColorOfCasualShoes { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ColorOfCasualShoes = await _context.ColorOfCasualShoes
                .Include(c => c.CasualShoes).FirstOrDefaultAsync(m => m.Id == id);

            if (ColorOfCasualShoes == null)
            {
                return NotFound();
            }
           ViewData["CasualShoesId"] = new SelectList(_context.CasualShoes, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ColorOfCasualShoes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorOfCasualShoesExists(ColorOfCasualShoes.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ColorOfCasualShoesExists(Guid id)
        {
            return _context.ColorOfCasualShoes.Any(e => e.Id == id);
        }
    }
}
