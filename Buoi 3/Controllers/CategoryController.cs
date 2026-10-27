using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Buoi_3.Models;

namespace Buoi_3.Controllers
{
    public class CategoryController : Controller
    {
        // gia lap csdl
        public static List<Category> categories = new List<Category>()
        {
            new Category { Id = 1, Name = "Xiaomi Redmi Tubor 3" },
            new Category { Id = 2, Name = "Xiaomi Redmi K70 pro" },
            new Category { Id = 3, Name = "Redmagic 11 pro" }
        };

        [HttpGet]
        // GET: CategoryController
        public ActionResult Index()
        {
            
            return View(categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                NotFound();
            }
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                category.Id = categories.Count + 1;
                categories.Add(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var Editcategory = categories.FirstOrDefault(c => c.Id == id);
            if (Editcategory == null)
            {
                return NotFound();
            }
            return View(Editcategory);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            var existingCategory = categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            existingCategory.Name = category.Name;
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var Deletedcategory = categories.FirstOrDefault(c => c.Id == id);
            if (Deletedcategory == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Category category)
        {
            var Deleteca = categories.FirstOrDefault(c => c.Id == category.Id);
            if (Deleteca == null)
            {
                return NotFound();
            }
            categories.Remove(Deleteca);

            return RedirectToAction(nameof(Index));
        }
    }
}
