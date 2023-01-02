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

namespace OrganizadorTarefas.Pages.Validacaoo
{
    public class EditModel : PageModel
    {
        private readonly OrganizadorTarefas.Data.OrganizadorTarefasContext _context;

        public EditModel(OrganizadorTarefas.Data.OrganizadorTarefasContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Validacao Validacao { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Validacao == null)
            {
                return NotFound();
            }

            var validacao =  await _context.Validacao.FirstOrDefaultAsync(m => m.Id == id);
            if (validacao == null)
            {
                return NotFound();
            }
            Validacao = validacao;
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

            _context.Attach(Validacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValidacaoExists(Validacao.Id))
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

        private bool ValidacaoExists(int id)
        {
          return _context.Validacao.Any(e => e.Id == id);
        }
    }
}
