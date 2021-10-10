using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotShopee.Client.Data;
using NotShopee.Client.Models;
using NotShopee.Client.Services;

namespace NotShopee.Client.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService; 
        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await productsService.GetAll();
            return View(products);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await productsService.Get(id.Value);
            
            if (product == null)
            {
                return NotFound();
            }
            
            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            // return View();
            throw new System.NotImplementedException();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,UserId,BoughtAt")] ProductViewModel productViewModel)
        {
            // if (ModelState.IsValid)
            // {
            //     _context.Add(productViewModel);
            //     await _context.SaveChangesAsync();
            //     return RedirectToAction(nameof(Index));
            // }
            // return View(productViewModel);
            throw new System.NotImplementedException();
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // if (id == null)
            // {
            //     return NotFound();
            // }
            //
            // var product = await _context.Product.FindAsync(id);
            // if (product == null)
            // {
            //     return NotFound();
            // }
            // return View(product);
            throw new System.NotImplementedException();
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,UserId,BoughtAt")] ProductViewModel productViewModel)
        {
            // if (id != productViewModel.Id)
            // {
            //     return NotFound();
            // }
            //
            // if (ModelState.IsValid)
            // {
            //     try
            //     {
            //         _context.Update(productViewModel);
            //         await _context.SaveChangesAsync();
            //     }
            //     catch (DbUpdateConcurrencyException)
            //     {
            //         if (!ProductExists(productViewModel.Id))
            //         {
            //             return NotFound();
            //         }
            //         else
            //         {
            //             throw;
            //         }
            //     }
            //     return RedirectToAction(nameof(Index));
            // }
            // return View(productViewModel);
            throw new System.NotImplementedException();
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            // if (id == null)
            // {
            //     return NotFound();
            // }
            //
            // var product = await _context.Product
            //     .FirstOrDefaultAsync(m => m.Id == id);
            // if (product == null)
            // {
            //     return NotFound();
            // }
            //
            // return View(product);
            throw new System.NotImplementedException();
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // var product = await _context.Product.FindAsync(id);
            // _context.Product.Remove(product);
            // await _context.SaveChangesAsync();
            // return RedirectToAction(nameof(Index));
            throw new System.NotImplementedException();
        }

        private bool ProductExists(int id)
        {
            // return _context.Product.Any(e => e.Id == id);
            throw new System.NotImplementedException();
        }
    }
}
