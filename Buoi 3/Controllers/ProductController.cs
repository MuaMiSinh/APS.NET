using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Buoi_3.Models;

namespace Buoi_3.Controllers
{
    public class ProductController : Controller
    {
        // gia lap csld
        public static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Xiaomi Redmi Tubor 3", Price = 10.0m, Description = "Hiệu năng cận cao cấp mạnh mẽ với chip Snapdragon 8s Gen 3, màn hình AMOLED 1.5K 120Hz mượt mà cùng thiết kế trẻ trung, tối ưu tốt cho tác vụ giải trí và chơi game. ", CategoryId =1 },
            new Product { Id = 2, Name = "Xiaomi Redmi 70 pro", Price = 20.0m, Description ="Flagship Killer cao cấp được xử lý bằng Snapdragon 8 Gen 3, màn hình OLED độ phân giải 2K sắc nét, khung kim loại sang trọng đi kèm sạc nhanh 120W.", CategoryId = 2 },
            new Product { Id = 3, Name = "Redmagic 11 pro", Price = 30.0m, Description = " Quái thú chơi game thế hệ mới với hiệu năng tối thượng, tích hợp quạt tản nhiệt cơ học RGB chủ động, phím trigger cảm ứng chuyên dụng và màn hình tràn biên không điểm.", CategoryId =3 }
        };
        // GET: ProductController
        public ActionResult Index()
        {
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int Id)
        {
            var product = products.FirstOrDefault(p => p.Id == Id);
            if (product == null)
            {
                return NotFound();
            }
                return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                product.Id = products.Count + 1;
                products.Add(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var editproduct = products.FirstOrDefault(p => p.Id == id);
            if (editproduct == null)
            {
                return NotFound();
            }
                return View(editproduct);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
          var exitproduct = products.FirstOrDefault(p => p.Id == product.Id);
            if (exitproduct == null)
            {
                return NotFound();
            }
            exitproduct.Name = product.Name;
            return RedirectToAction(nameof (Index));
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
