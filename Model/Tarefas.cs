namespace OrganizadorTarefas.Model
{
    public class Tarefas
    {
        
        public int Id { get; set; } //PK
        public int codUfcd { get; set; }
        public string nomeUfcd { get; set; }
        public string descricao { get; set; }
        public DateTime dataEntrega { get; set; }
    }
}
