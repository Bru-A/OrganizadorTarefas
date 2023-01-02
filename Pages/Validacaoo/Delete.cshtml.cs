using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrganizadorTarefas.Data;
using OrganizadorTarefas.Model;

namespace OrganizadorTarefas.Pages.Validacaoo
{
    public class DeleteModel : PageModel
    {
        private readonly OrganizadorTarefas.Data.OrganizadorTarefasContext _context;

        public DeleteModel(OrganizadorTarefas.Data.OrganizadorTarefasContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Validacao Validacao { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Validacao == null)
            {
                return NotFound();
            }

            var validacao = await _context.Validacao.FirstOrDefaultAsync(m => m.Id == id);

            if (validacao == null)
            {
                return NotFound();
            }
            else 
            {
                Validacao = validacao;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Validacao == null)
            {
                return NotFound();
            }
            var validacao = await _context.Validacao.FindAsync(id);

            if (validacao != null)
            {
                Validacao = validacao;
                _context.Validacao.Remove(Validacao);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
