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
    public class DetailsModel : PageModel
    {
        private readonly OrganizadorTarefas.Data.OrganizadorTarefasContext _context;

        public DetailsModel(OrganizadorTarefas.Data.OrganizadorTarefasContext context)
        {
            _context = context;
        }

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
    }
}
