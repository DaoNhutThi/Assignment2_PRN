using Asignment002.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ShoppingWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        [BindProperty(SupportsGet = true)]
        public string? SearchAS { get; set; }

        private readonly Asignment002.Data.PizzaStoreContext _context;

        public IndexModel(Asignment002.Data.PizzaStoreContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Products != null)
            {
                var products = from p in _context.Products select p;
                if (!string.IsNullOrEmpty(SearchAS))
                {
                    products = products.Where(s => s.ProductName.Contains(SearchAS));
                    products.Include(p => p.Category).Include(p => p.Supplier);
                }
                Product = await products.ToListAsync();
            }
        }
    }
}