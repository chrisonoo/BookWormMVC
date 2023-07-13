using BookWorm.MVC.Data;
using BookWorm.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookWorm.MVC.Controllers;

public class ContributorRolesController : Controller
{
    private readonly ApplicationDbContext _context;

    public ContributorRolesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: ContributorRoles
    public async Task<IActionResult> Index()
    {
        return _context.ContributorRoles != null ?
                    View(await _context.ContributorRoles.ToListAsync()) :
                    Problem("Entity set 'ApplicationDbContext.ContributorRoles'  is null.");
    }

    // GET: ContributorRoles/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if(id == null || _context.ContributorRoles == null)
        {
            return NotFound();
        }

        var contributorRole = await _context.ContributorRoles
            .FirstOrDefaultAsync(m => m.Id == id);
        if(contributorRole == null)
        {
            return NotFound();
        }

        return View(contributorRole);
    }

    // GET: ContributorRoles/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ContributorRoles/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name")] ContributorRole contributorRole)
    {
        if(ModelState.IsValid)
        {
            _context.Add(contributorRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(contributorRole);
    }

    // GET: ContributorRoles/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if(id == null || _context.ContributorRoles == null)
        {
            return NotFound();
        }

        var contributorRole = await _context.ContributorRoles.FindAsync(id);
        if(contributorRole == null)
        {
            return NotFound();
        }
        return View(contributorRole);
    }

    // POST: ContributorRoles/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ContributorRole contributorRole)
    {
        if(id != contributorRole.Id)
        {
            return NotFound();
        }

        if(ModelState.IsValid)
        {
            try
            {
                _context.Update(contributorRole);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!ContributorRoleExists(contributorRole.Id))
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
        return View(contributorRole);
    }

    // GET: ContributorRoles/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if(id == null || _context.ContributorRoles == null)
        {
            return NotFound();
        }

        var contributorRole = await _context.ContributorRoles
            .FirstOrDefaultAsync(m => m.Id == id);
        if(contributorRole == null)
        {
            return NotFound();
        }

        return View(contributorRole);
    }

    // POST: ContributorRoles/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if(_context.ContributorRoles == null)
        {
            return Problem("Entity set 'ApplicationDbContext.ContributorRoles'  is null.");
        }
        var contributorRole = await _context.ContributorRoles.FindAsync(id);
        if(contributorRole != null)
        {
            _context.ContributorRoles.Remove(contributorRole);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ContributorRoleExists(int id)
    {
        return (_context.ContributorRoles?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
