using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio_of_Joe.Models;

namespace Portfolio_of_Joe.Controllers
{
    public class HeroesController : Controller
    {
        private readonly Portfolio_of_JoeContext _context;

        public HeroesController(Portfolio_of_JoeContext context)
        {
            _context = context;
        }

        // GET: Heroes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hero.ToListAsync());
        }

        // GET: Heroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hero = await _context.Hero
                .FirstOrDefaultAsync(m => m.HeroID == id);
            if (hero == null)
            {
                return NotFound();
            }

            return View(hero);
        }

        // GET: Heroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Heroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HeroID,HeroName")] Hero hero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hero);
        }

        // GET: Heroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hero = await _context.Hero.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }
            return View(hero);
        }

        // POST: Heroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HeroID,HeroName")] Hero hero)
        {
            if (id != hero.HeroID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeroExists(hero.HeroID))
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
            return View(hero);
        }

        // GET: Heroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hero = await _context.Hero
                .FirstOrDefaultAsync(m => m.HeroID == id);
            if (hero == null)
            {
                return NotFound();
            }

            return View(hero);
        }

        // POST: Heroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hero = await _context.Hero.FindAsync(id);
            _context.Hero.Remove(hero);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeroExists(int id)
        {
            return _context.Hero.Any(e => e.HeroID == id);
        }
    }
}
