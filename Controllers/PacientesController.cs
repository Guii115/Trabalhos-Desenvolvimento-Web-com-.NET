
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Agendamento.Models;
using Agendamento.Data;

public class PacientesController : Controller
{
    private readonly AppDbContext _context;

    public PacientesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: PACIENTES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Pacientes.ToListAsync());
    }

    // GET: PACIENTES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var paciente = await _context.Pacientes
            .FirstOrDefaultAsync(m => m.Id == id);
        if (paciente == null)
        {
            return NotFound();
        }

        return View(paciente);
    }

    // GET: PACIENTES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PACIENTES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Telefone,Endereco,DataNascimento")] Paciente paciente)
    {
        if (ModelState.IsValid)
        {
            _context.Add(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(paciente);
    }

    // GET: PACIENTES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var paciente = await _context.Pacientes.FindAsync(id);
        if (paciente == null)
        {
            return NotFound();
        }
        return View(paciente);
    }

    // POST: PACIENTES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nome,Cpf,Telefone,Endereco,DataNascimento")] Paciente paciente)
    {
        if (id != paciente.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(paciente);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(paciente.Id))
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
        return View(paciente);
    }

    // GET: PACIENTES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var paciente = await _context.Pacientes
            .FirstOrDefaultAsync(m => m.Id == id);
        if (paciente == null)
        {
            return NotFound();
        }

        return View(paciente);
    }

    // POST: PACIENTES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var paciente = await _context.Pacientes.FindAsync(id);
        if (paciente != null)
        {
            _context.Pacientes.Remove(paciente);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PacienteExists(int? id)
    {
        return _context.Pacientes.Any(e => e.Id == id);
    }
}
