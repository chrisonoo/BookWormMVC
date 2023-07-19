using BookWorm.MVC.Data;
using BookWorm.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookWorm.MVC.Controllers;

public class BooksController : Controller
{
    private readonly ApplicationDbContext _context;

    public BooksController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Books
    public async Task<IActionResult> Index()
    {
        var books = await _context.Books
            .Include(b => b.Publisher)
            .ToListAsync();
        return View(books);
    }

    // GET: Books/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if(id == null || _context.Books == null)
        {
            return NotFound();
        }

        var book = await _context.Books
            .Include(b => b.Publisher)
            .Include(b => b.BookContributors)
            .ThenInclude(bc => bc.Contributor)
            .Include(b => b.BookContributors)
            .ThenInclude(bc => bc.ContributorRole)
            .FirstOrDefaultAsync(m => m.Id == id);
        if(book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    // GET: Books/Create
    public IActionResult Create()
    {
        ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name");
        return View();
    }

    // POST: Books/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,PublicationYear,PublisherId")] Book book)
    {
        if(ModelState.IsValid)
        {
            _context.Add(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name", book.PublisherId);
        return View(book);
    }

    // GET: Books/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if(id == null || _context.Books == null)
        {
            return NotFound();
        }

        var book = await _context.Books.FindAsync(id);
        if(book == null)
        {
            return NotFound();
        }
        ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name", book.PublisherId);
        return View(book);
    }

    // POST: Books/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,PublicationYear,PublisherId")] Book book)
    {
        if(id != book.Id)
        {
            return NotFound();
        }

        if(ModelState.IsValid)
        {
            try
            {
                _context.Update(book);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!BookExists(book.Id))
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
        ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name", book.PublisherId);
        return View(book);
    }

    // GET: Books/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if(id == null || _context.Books == null)
        {
            return NotFound();
        }

        var book = await _context.Books
            .Include(b => b.Publisher)
            .FirstOrDefaultAsync(m => m.Id == id);
        if(book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    // POST: Books/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if(_context.Books == null)
        {
            return Problem("Entity set 'ApplicationDbContext.Books'  is null.");
        }
        var book = await _context.Books.FindAsync(id);
        if(book != null)
        {
            _context.Books.Remove(book);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BookExists(int id)
    {
        return (_context.Books?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
