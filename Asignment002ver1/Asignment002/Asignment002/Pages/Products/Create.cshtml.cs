using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Asignment002.Areas.Identity.Data;
using Asignment002.Data;
using Microsoft.AspNetCore.Authorization;

namespace Asignment002.Pages.Products
{

    public class CreateModel : PageModel
    {
        private readonly Asignment002.Data.PizzaStoreContext _context;

        public CreateModel(Asignment002.Data.PizzaStoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategogyID"] = new SelectList(_context.Categories, "Id", "Id");
        ViewData["SupplierID"] = new SelectList(_context.Suppliers, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
         
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
