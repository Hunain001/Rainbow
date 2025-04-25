using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rainbow.Models;
using System.Diagnostics;

namespace Rainbow.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        rainbowContext r1;
        public HomeController(ILogger<HomeController> logger, rainbowContext r1)
        {
            _logger = logger;
            this.r1 = r1;
        }

        public IActionResult Index()
        {
            var specials = r1.cakes.Where(c => c.isspecial == "Yes").Take(6).ToList();
            var offer = r1.offers.FirstOrDefault();
            var cakes = r1.cakes.Take(2).ToList();

            ViewBag.SpecialCakes = specials;
            ViewBag.Offer = offer;
            ViewBag.OfferCakes = cakes;
            var featuredCake = r1.cakes.FirstOrDefault(); // or pick based on some condition
            ViewBag.FeaturedCake = featuredCake;



            return View();
        }





        public IActionResult Areg()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Areg(Admin a)
        {
            r1.admins.Add(a);
            r1.SaveChanges();
            ModelState.Clear();
            return View();
        }

        public IActionResult Alogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alogin(Admin a)
        {
            var b = r1.admins.FirstOrDefault(x => x.Email == a.Email && x.Password == a.Password);

            if (b != null)
            {
                HttpContext.Session.SetInt32("Aid", b.Id);
                return RedirectToAction("Adash");
            }
            ViewData["k"] = "Invalid Email or Password";
            return View();
        }

        public IActionResult Adash()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Categourie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Categourie(Categoury c)

        {
            r1.categories.Add(c);
            r1.SaveChanges();
            ModelState.Clear();
            return View();
        }

        public IActionResult cake()
        {
            var d = r1.categories.ToList();
            ViewBag.categories = new SelectList(d, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult cake(Cake c, IFormFile imageFile)
        {
            var d = r1.categories.ToList();
            ViewBag.categories = new SelectList(d, "Id", "Name");

            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                c.image = "/image/" + fileName;
            }

            r1.cakes.Add(c);
            r1.SaveChanges();
            ModelState.Clear();


            return View();
        }



        public IActionResult DisplayC()
        {
            var d = r1.cakes.Include(c => c.Categoury).ToList();
            return View(d);
        }

        public IActionResult Delete(int id)
        {
            var d = r1.cakes.Find(id);
            r1.Remove(d);
            r1.SaveChanges();
            return RedirectToAction("DisplayC");
        }

        public IActionResult Edit(int id)
        {
            var c = r1.cakes.Find(id);
            var d = r1.categories.ToList();
            ViewBag.categories = new SelectList(d, "Id", "Name");
            return View(c);
        }

        [HttpPost]
        public IActionResult Edit(Cake c, IFormFile imageFile)
        {
            var d = r1.categories.ToList();
            ViewBag.categories = new SelectList(d, "Id", "Name");

            Cake cc = r1.cakes.Find(c.CId);

            if (cc == null)
                return NotFound();

            if (!r1.categories.Any(x => x.Id == c.id))
            {
                ModelState.AddModelError("id", "Invalid category selected.");
                return View(c);
            }

            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                cc.image = "/image/" + fileName;
            }
            else
            {
                cc.image = r1.cakes.AsNoTracking().FirstOrDefault(x => x.CId == c.CId)?.image;
            }

            cc.CakeName = c.CakeName;
            cc.Description = c.Description;
            cc.Price = c.Price;
            cc.id = c.id;

            r1.SaveChanges();

            return RedirectToAction("DisplayC");
        }






        public IActionResult offer()
        { return View(); }

        [HttpPost]
        public IActionResult offer(Offer o)
        {
            r1.offers.Add(o);
            r1.SaveChanges();
            ModelState.Clear();
            return View();
        }


        public IActionResult Gallery(int? categoryId, string searchTerm)
        {
            var cate = r1.categories.ToList();
            ViewBag.Categories = cate;
            ViewBag.SearchTerm = searchTerm;

            var cakes = r1.cakes.AsQueryable();

            if (categoryId.HasValue)
            {
                cakes = cakes.Where(c => c.id == categoryId.Value);

            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                cakes = cakes.Where(c => c.CakeName.Contains(searchTerm) || c.Price.Contains(searchTerm));
            }

            var limitedCakes = cakes.Take(20).ToList(); 

            return View(limitedCakes);
        }



        public IActionResult CakeDetails(int id)
        {
            var cake = r1.cakes.Include(c => c.Categoury)
                               .FirstOrDefault(c => c.CId == id);
           

            if (cake == null)
            {
                return NotFound();
            }

         


            return View(cake);
        }

        public IActionResult Doffer()
        {
            var d = r1.offers.ToList();
            return View(d);
        }

        public IActionResult Deleteo(int id)
        {
            var d = r1.offers.Find(id);
            r1.Remove(d);
            r1.SaveChanges();
            return RedirectToAction("Doffer");
        }

     



    }
}
