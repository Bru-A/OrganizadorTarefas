using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrganizadorTarefas.Model;

namespace OrganizadorTarefas.Data
{
    public class OrganizadorTarefasContext : DbContext
    {
        public OrganizadorTarefasContext (DbContextOptions<OrganizadorTarefasContext> options)
            : base(options)
        {
        }

        public DbSet<OrganizadorTarefas.Model.Tarefas> Tarefas { get; set; } = default!;

        public DbSet<OrganizadorTarefas.Model.Validacao> Validacao { get; set; }
    }
}
