using jobmanager.Data.Data;
using jobmanager.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobManager.Controllers
{
    public class IsIlaniController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public IsIlaniController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // LIST
        public IActionResult Index(string searchString)
        {
            var result = dbContext.IsIlanlari
                .Include(x => x.Sirket)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                result = result.Where(x => x.Baslik.Contains(searchString));
            }

            return View(result.ToList());
        }

        // CREATE GET
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Sirketler = dbContext.Sirketler.ToList();
            return View();
        }

        // CREATE POST (SADECE 1 PARAMETRE - DOĞRU)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IsIlani ilan)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Sirketler = dbContext.Sirketler.ToList();
                return View(ilan);
            }

            if (ilan.SirketId == 0)
            {
                ModelState.AddModelError("", "Şirket seçmelisiniz");
                ViewBag.Sirketler = dbContext.Sirketler.ToList();
                return View(ilan);
            }

            ilan.YayimlanmaTarihi = DateTime.Now;

            dbContext.IsIlanlari.Add(ilan);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // EDIT GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ilan = dbContext.IsIlanlari.Find(id);

            if (ilan == null)
                return NotFound();

            ViewBag.Sirketler = dbContext.Sirketler.ToList();

            return View(ilan);
        }

        // EDIT POST (SADECE 1 PARAMETRE)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(IsIlani ilan)
        {
            var mevcut = dbContext.IsIlanlari.Find(ilan.IsIlaniId);

            if (mevcut == null)
                return NotFound();

            mevcut.Baslik = ilan.Baslik;
            mevcut.Aciklama = ilan.Aciklama;
            mevcut.Maas = ilan.Maas;
            mevcut.Sehir = ilan.Sehir;
            mevcut.SirketId = ilan.SirketId;
            mevcut.SonBasvuruTarihi = ilan.SonBasvuruTarihi;

            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // DELETE GET
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var ilan = dbContext.IsIlanlari
                .Include(x => x.Sirket)
                .FirstOrDefault(x => x.IsIlaniId == id);

            if (ilan == null)
                return NotFound();

            return View(ilan);
        }

        // DELETE POST (SADECE ID ALIR - EN DOĞRU YÖNTEM)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ilan = dbContext.IsIlanlari.Find(id);

            if (ilan != null)
            {
                dbContext.IsIlanlari.Remove(ilan);
                dbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}