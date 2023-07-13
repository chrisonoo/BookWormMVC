using BookWorm.MVC.Data;
using BookWorm.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookWorm.MVC.Controllers;

public class BookContributorsController : Controller
{
    private readonly ApplicationDbContext _context;

    public BookContributorsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: BookContributors
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.BookContributors.Include(b => b.Book).Include(b => b.Contributor).Include(b => b.ContributorRole);
        return View(await applicationDbContext.ToListAsync());
    }

    // GET: BookContributors/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if(id == null || _context.BookContributors == null)
        {
            return NotFound();
        }

        var bookContributor = await _context.BookContributors
            .Include(b => b.Book)
            .Include(b => b.Contributor)
            .Include(b => b.ContributorRole)
            .FirstOrDefaultAsync(m => m.BookId == id);
        if(bookContributor == null)
        {
            return NotFound();
        }

        return View(bookContributor);
    }

    // GET: BookContributors/Create
    public IActionResult Create()
    {
        ViewData["BookId"] = new SelectList(_context.Books, "Id", "Title");
        ViewData["ContributorId"] = new SelectList(_context.Contributors, "Id", "Name");
        ViewData["ContributorRoleId"] = new SelectList(_context.ContributorRoles, "Id", "Name");
        return View();
    }

    // POST: BookContributors/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("BookId,ContributorId,ContributorRoleId")] BookContributor bookContributor)
    {
        if(ModelState.IsValid)
        {
            _context.Add(bookContributor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["BookId"] = new SelectList(_context.Books, "Id", "Title", bookContributor.BookId);
        ViewData["ContributorId"] = new SelectList(_context.Contributors, "Id", "Name", bookContributor.ContributorId);
        ViewData["ContributorRoleId"] = new SelectList(_context.ContributorRoles, "Id", "Name", bookContributor.ContributorRoleId);
        return View(bookContributor);
    }

    // GET: BookContributors/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if(id == null || _context.BookContributors == null)
        {
            return NotFound();
        }

        var bookContributor = await _context.BookContributors.FindAsync(id);
        if(bookContributor == null)
        {
            return NotFound();
        }
        ViewData["BookId"] = new SelectList(_context.Books, "Id", "Title", bookContributor.BookId);
        ViewData["ContributorId"] = new SelectList(_context.Contributors, "Id", "Name", bookContributor.ContributorId);
        ViewData["ContributorRoleId"] = new SelectList(_context.ContributorRoles, "Id", "Name", bookContributor.ContributorRoleId);
        return View(bookContributor);
    }

    // POST: BookContributors/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("BookId,ContributorId,ContributorRoleId")] BookContributor bookContributor)
    {
        if(id != bookContributor.BookId)
        {
            return NotFound();
        }

        if(ModelState.IsValid)
        {
            try
            {
                _context.Update(bookContributor);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!BookContributorExists(bookContributor.BookId))
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
        ViewData["BookId"] = new SelectList(_context.Books, "Id", "Title", bookContributor.BookId);
        ViewData["ContributorId"] = new SelectList(_context.Contributors, "Id", "Name", bookContributor.ContributorId);
        ViewData["ContributorRoleId"] = new SelectList(_context.ContributorRoles, "Id", "Name", bookContributor.ContributorRoleId);
        return View(bookContributor);
    }

    // GET: BookContributors/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if(id == null || _context.BookContributors == null)
        {
            return NotFound();
        }

        var bookContributor = await _context.BookContributors
            .Include(b => b.Book)
            .Include(b => b.Contributor)
            .Include(b => b.ContributorRole)
            .FirstOrDefaultAsync(m => m.BookId == id);
        if(bookContributor == null)
        {
            return NotFound();
        }

        return View(bookContributor);
    }

    // POST: BookContributors/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if(_context.BookContributors == null)
        {
            return Problem("Entity set 'ApplicationDbContext.BookContributors'  is null.");
        }
        var bookContributor = await _context.BookContributors.FindAsync(id);
        if(bookContributor != null)
        {
            _context.BookContributors.Remove(bookContributor);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BookContributorExists(int id)
    {
        return (_context.BookContributors?.Any(e => e.BookId == id)).GetValueOrDefault();
    }
}
