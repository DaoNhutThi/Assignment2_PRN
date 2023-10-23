using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asignment002.Areas.Identity.Data;
using Asignment002.Data;

namespace Asignment002.Pages.OrderDetails
{
    public class DeleteModel : PageModel
    {
        private readonly Asignment002.Data.PizzaStoreContext _context;

        public DeleteModel(Asignment002.Data.PizzaStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
      public OrderDetail OrderDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.OrdersDetails == null)
            {
                return NotFound();
            }

            var orderdetail = await _context.OrdersDetails.FirstOrDefaultAsync(m => m.Id == id);

            if (orderdetail == null)
            {
                return NotFound();
            }
            else 
            {
                OrderDetail = orderdetail;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.OrdersDetails == null)
            {
                return NotFound();
            }
            var orderdetail = await _context.OrdersDetails.FindAsync(id);

            if (orderdetail != null)
            {
                OrderDetail = orderdetail;
                _context.OrdersDetails.Remove(OrderDetail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
