using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrganizadorTarefas.Data;
using OrganizadorTarefas.Model;

namespace OrganizadorTarefas.Pages.Tarefa
{
    public class DeleteModel : PageModel
    {
        private readonly OrganizadorTarefas.Data.OrganizadorTarefasContext _context;

        public DeleteModel(OrganizadorTarefas.Data.OrganizadorTarefasContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Tarefas Tarefas { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tarefas == null)
            {
                return NotFound();
            }

            var tarefas = await _context.Tarefas.FirstOrDefaultAsync(m => m.Id == id);

            if (tarefas == null)
            {
                return NotFound();
            }
            else 
            {
                Tarefas = tarefas;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tarefas == null)
            {
                return NotFound();
            }
            var tarefas = await _context.Tarefas.FindAsync(id);

            if (tarefas != null)
            {
                Tarefas = tarefas;
                _context.Tarefas.Remove(Tarefas);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
