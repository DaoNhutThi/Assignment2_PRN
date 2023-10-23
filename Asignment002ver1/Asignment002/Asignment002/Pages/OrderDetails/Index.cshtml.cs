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
    public class IndexModel : PageModel
    {
        private readonly Asignment002.Data.PizzaStoreContext _context;

        public IndexModel(Asignment002.Data.PizzaStoreContext context)
        {
            _context = context;
        }

        public IList<OrderDetail> OrderDetail { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.OrdersDetails != null)
            {
                OrderDetail = await _context.OrdersDetails
                .Include(o => o.Order)
                .Include(o => o.Product).ToListAsync();
            }
        }
    }
}
