using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrganizadorTarefas.Data;
using OrganizadorTarefas.Model;

namespace OrganizadorTarefas.Pages.Tarefa
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
        public Tarefas Tarefas { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tarefas.Add(Tarefas);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
