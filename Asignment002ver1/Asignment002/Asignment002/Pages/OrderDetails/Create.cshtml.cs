using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Asignment002.Areas.Identity.Data;
using Asignment002.Data;

namespace Asignment002.Pages.OrderDetails
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
        ViewData["OrderID"] = new SelectList(_context.Orders, "Id", "Id");
        ViewData["ProductID"] = new SelectList(_context.Products, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.OrdersDetails == null || OrderDetail == null)
            {
                return Page();
            }

            _context.OrdersDetails.Add(OrderDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
