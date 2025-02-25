using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task7.Models;


namespace Task7.Controllers
{
    public class AdminController : Controller
    {
        private readonly MyDbContext _context;

        public AdminController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> UsersView()
        {
            return View(await _context.Users.ToListAsync());
        }

        public async Task<IActionResult> ProductView()
        {
            return View(await _context.Products.ToListAsync());
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult ProductDetails(int? id)
        {

            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult ProductCreate()
        {
            return View();
        }


        [HttpPost]

        public IActionResult ProductCreate(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(ProductView));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public IActionResult ProductEdit(int? id)
        {

            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        [HttpPost]
        public IActionResult ProductEdit(Product product)
        {

            _context.Update(product);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        // GET: Products/Delete/5
        public IActionResult ProductDelete(int? id)
        {
            var product = _context.Products.Find(id);
            _context.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("ProductView");
        }

        //----------------------------------------------------------------------------------


        public IActionResult UsersDetails(int? id)
        {

            var product = _context.Users.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult UsersCreate()
        {
            return View();
        }


        [HttpPost]

        public IActionResult UsersCreate(User Users)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Users);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(ProductView));
            }
            return View(Users);
        }

        // GET: Products/Edit/5
        public IActionResult UsersEdit(int? id)
        {

            var Users = _context.Users.Find(id);
            if (Users == null)
            {
                return NotFound();
            }
            return View(Users);
        }


        [HttpPost]
        public IActionResult UsersEdit(User Users)
        {

            _context.Update(Users);
            _context.SaveChanges();

            return RedirectToAction(nameof(UsersView));

        }

        // GET: Products/Delete/5
        public IActionResult UsersDelete(int? id)
        {
            var Users = _context.Users.Find(id);
            _context.Remove(Users);
            _context.SaveChanges();
            return RedirectToAction("UsersView");
        }
    }
}