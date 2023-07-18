using BookWorm.MVC.Data;
using BookWorm.MVC.Models;
using BookWorm.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookWorm.MVC.Controllers;

public class PublishersController : Controller
{
    private readonly ApplicationDbContext _context;

    public PublishersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Publishers
    public async Task<IActionResult> Index()
    {
        if(_context.Publishers != null)
        {
            var publishers = await _context.Publishers
                .Include(p => p.Books)
                .ToListAsync();
            var publishersToView = publishers.Select(p => new PublisherViewModel
            {
                Id = p.Id,
                Name = p.Name,
                BookCount = p.Books == null ? 0 : p.Books.Count,
                IsActive = p.IsActive
            })
                .OrderByDescending(p => p.BookCount)
                .ToList();

            return View(publishersToView);
        }
        else
        {
            // Returning an empty List will allows to display the appropriate message in the View
            return View(new List<PublisherViewModel>());
        }
    }

    // GET: Publishers/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if(id == null || _context.Publishers == null)
        {
            return NotFound();
        }

        var publisher = await _context.Publishers
            .Include(p => p.Books)
            .FirstOrDefaultAsync(m => m.Id == id);
        if(publisher == null)
        {
            return NotFound();
        }

        return View(publisher);
    }

    // GET: Publishers/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Publishers/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name")] Publisher publisher)
    {
        if(ModelState.IsValid)
        {
            _context.Add(publisher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(publisher);
    }

    // GET: Publishers/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if(id == null || _context.Publishers == null)
        {
            return NotFound();
        }

        var publisher = await _context.Publishers.FindAsync(id);
        if(publisher == null)
        {
            return NotFound();
        }
        return View(publisher);
    }

    // POST: Publishers/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IsActive")] Publisher publisher)
    {
        if(id != publisher.Id)
        {
            return NotFound();
        }

        if(ModelState.IsValid)
        {
            try
            {
                _context.Update(publisher);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!PublisherExists(publisher.Id))
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
        return View(publisher);
    }

    // GET: Publishers/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if(id == null || _context.Publishers == null)
        {
            return NotFound();
        }

        var publisher = await _context.Publishers
            .FirstOrDefaultAsync(m => m.Id == id);
        if(publisher == null)
        {
            return NotFound();
        }

        return View(publisher);
    }

    // POST: Publishers/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if(_context.Publishers == null)
        {
            return Problem("Entity set 'ApplicationDbContext.Publishers'  is null.");
        }
        var publisher = await _context.Publishers.FindAsync(id);
        if(publisher != null)
        {
            publisher.IsActive = false;
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PublisherExists(int id)
    {
        return (_context.Publishers?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
