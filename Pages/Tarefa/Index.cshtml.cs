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
    public class IndexModel : PageModel
    {
        private readonly OrganizadorTarefas.Data.OrganizadorTarefasContext _context;

        public IndexModel(OrganizadorTarefas.Data.OrganizadorTarefasContext context)
        {
            _context = context;
        }

        public IList<Tarefas> Tarefas { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Tarefas != null)
            {
                Tarefas = await _context.Tarefas.ToListAsync();
            }
        }
    }
}
