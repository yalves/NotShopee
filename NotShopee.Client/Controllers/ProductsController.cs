using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotShopee.Client.Models;
using NotShopee.Client.Services;

namespace NotShopee.Client.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService; 
        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await _productsService.GetAll();
            return View(products);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productsService.Get(id.Value);
            
            if (product == null)
            {
                return NotFound();
            }
            
            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,UserId,BoughtAt")] ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                await _productsService.Create(productViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(productViewModel);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var product = await _productsService.Get(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,UserId,BoughtAt")] ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                await _productsService.Edit(productViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(productViewModel);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productsService.Get(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productsService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        
        // GET: Products/monthly
        [Route("Products/Monthly")]
        public async Task<IActionResult> Report()
        {
            var products = await _productsService.GetMonthlyReport();
            return View(products);
        }
    }
}
