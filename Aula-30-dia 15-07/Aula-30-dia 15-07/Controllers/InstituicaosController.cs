using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aula_30_dia_15_07.Models;

namespace Aula_30_dia_15_07.Controllers
{
    public class InstituicaosController : Controller
    {
        private readonly Context _context;

        public InstituicaosController(Context context)
        {
            _context = context;
        }

        // GET: Instituicaos
        public async Task<IActionResult> Index()
        {
              return _context.instituicoes != null ? 
                          View(await _context.instituicoes.ToListAsync()) :
                          Problem("Entity set 'Context.instituicoes'  is null.");
        }

        // GET: Instituicaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.instituicoes == null)
            {
                return NotFound();
            }

            var instituicao = await _context.instituicoes
                .FirstOrDefaultAsync(m => m.id == id);
            if (instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }

        // GET: Instituicaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instituicaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,endereco,cnpj")] Instituicao instituicao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instituicao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instituicao);
        }

        // GET: Instituicaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.instituicoes == null)
            {
                return NotFound();
            }

            var instituicao = await _context.instituicoes.FindAsync(id);
            if (instituicao == null)
            {
                return NotFound();
            }
            return View(instituicao);
        }

        // POST: Instituicaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,endereco,cnpj")] Instituicao instituicao)
        {
            if (id != instituicao.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instituicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstituicaoExists(instituicao.id))
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
            return View(instituicao);
        }

        // GET: Instituicaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.instituicoes == null)
            {
                return NotFound();
            }

            var instituicao = await _context.instituicoes
                .FirstOrDefaultAsync(m => m.id == id);
            if (instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }

        // POST: Instituicaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.instituicoes == null)
            {
                return Problem("Entity set 'Context.instituicoes'  is null.");
            }
            var instituicao = await _context.instituicoes.FindAsync(id);
            if (instituicao != null)
            {
                _context.instituicoes.Remove(instituicao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstituicaoExists(int id)
        {
          return (_context.instituicoes?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
