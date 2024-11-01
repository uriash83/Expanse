using Expanse.DataAccess.Data;
using Expanse.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Expanse.Controllers
{
    public class CryptoController : Controller
    {
        public readonly ExpanseDbContext _context;
        public CryptoController(ExpanseDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var listCrypto = await _context.CryptoCurrencies.ToListAsync();
            return View(listCrypto);
        }

        public IActionResult Create()
        {


            return View();

        }

        // POST: Crypto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CryptoCurrency model)
        {
            if (ModelState.IsValid)
            {
                _context.CryptoCurrencies.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model); // wraca do formularza, jeśli dane są niepoprawne
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CryptoCurrencies == null)
            {
                return NotFound();
            }

            var cryptoCurrency = await _context.CryptoCurrencies.FirstOrDefaultAsync(i => i.Id == id);
            return View(cryptoCurrency);
        }

        // POST: Crypto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CryptoCurrency model)
        {
            if(id != model.Id)
            {
                NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.CryptoCurrencies.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View(model); // Wróć do formularza, jeśli dane są niepoprawne
        }

        public async Task<IActionResult> Delete(int? id) {
            if (id == null || _context.CryptoCurrencies == null)
            {
                return NotFound();
            }

            var cryptoCurrency = await _context.CryptoCurrencies.FirstOrDefaultAsync(i => i.Id == id);
            return View(cryptoCurrency);
        }

        //POST: Crypto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var asset = _context.CryptoCurrencies.Find(id);
            if (asset != null)
            {
                _context.CryptoCurrencies.Remove(asset);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
