using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrganizadorTarefas.Data;
using OrganizadorTarefas.Model;

namespace OrganizadorTarefas.Pages.Validacaoo
{
    public class CreateModel : PageModel
    {
        private readonly OrganizadorTarefas.Data.OrganizadorTarefasContext _context;

        public CreateModel(OrganizadorTarefas.Data.OrganizadorTarefasContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Validacao Validacao { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Validacao.Add(Validacao);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
