using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DogFood.Data;
using Misfits.Models.Data;

namespace DogFood.Controllers
{
    public class DogFoodModelsController : Controller
    {
        private readonly DogFoodContext _context;

        public DogFoodModelsController(DogFoodContext context)
        {
            _context = context;
        }

        // GET: DogFoodModels
        public async Task<IActionResult> Index()
        {
              return _context.DogFoods != null ? 
                          View(await _context.DogFoods.ToListAsync()) :
                          Problem("Entity set 'DogFoodContext.DogFoods'  is null.");
        }

        // GET: DogFoodModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DogFoods == null)
            {
                return NotFound();
            }

            var dogFoodModel = await _context
                .DogFoods
                .Include(d => d.Reviews)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dogFoodModel == null)
            {
                return NotFound();
            }

            return View(dogFoodModel);
        }

        // GET: DogFoodModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DogFoodModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DogFoodName,Description,ImageURL,Ingredients,ProductionCompany")] DogFoodModel dogFoodModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dogFoodModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dogFoodModel);
        }

        // GET: DogFoodModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DogFoods == null)
            {
                return NotFound();
            }

            var dogFoodModel = await _context.DogFoods.FindAsync(id);
            if (dogFoodModel == null)
            {
                return NotFound();
            }
            return View(dogFoodModel);
        }

        // POST: DogFoodModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DogFoodName,Description,ImageURL,Ingredients,ProductionCompany")] DogFoodModel dogFoodModel)
        {
            if (id != dogFoodModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dogFoodModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DogFoodModelExists(dogFoodModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dogFoodModel);
        }

        // GET: DogFoodModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DogFoods == null)
            {
                return NotFound();
            }

            var dogFoodModel = await _context.DogFoods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dogFoodModel == null)
            {
                return NotFound();
            }

            return View(dogFoodModel);
        }

        // POST: DogFoodModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DogFoods == null)
            {
                return Problem("Entity set 'DogFoodContext.DogFoods'  is null.");
            }
            var dogFoodModel = await _context.DogFoods.FindAsync(id);
            if (dogFoodModel != null)
            {
                _context.DogFoods.Remove(dogFoodModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> CreateReview(int id)
        {
            ReviewModel review = new ReviewModel();
            review.DogFoodModelId = id;

          
            return View(review);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReview(ReviewModel reviewModel)
        {
            reviewModel.DogFoodModelId = reviewModel.Id;
            reviewModel.Id = 0;
            _context.Add(reviewModel);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool DogFoodModelExists(int id)
        {
          return (_context.DogFoods?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
