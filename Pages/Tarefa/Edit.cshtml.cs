using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrganizadorTarefas.Data;
using OrganizadorTarefas.Model;

namespace OrganizadorTarefas.Pages.Tarefa
{
    public class EditModel : PageModel
    {
        private readonly OrganizadorTarefas.Data.OrganizadorTarefasContext _context;

        public EditModel(OrganizadorTarefas.Data.OrganizadorTarefasContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tarefas Tarefas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tarefas == null)
            {
                return NotFound();
            }

            var tarefas =  await _context.Tarefas.FirstOrDefaultAsync(m => m.Id == id);
            if (tarefas == null)
            {
                return NotFound();
            }
            Tarefas = tarefas;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Tarefas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefasExists(Tarefas.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TarefasExists(int id)
        {
          return _context.Tarefas.Any(e => e.Id == id);
        }
    }
}
