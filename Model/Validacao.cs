namespace OrganizadorTarefas.Model
{
    public class Validacao
    {
        public int Id { get; set; } //PK
        public string codUfcd { get; set; }
        public bool entregaPra { get; set; }
        public bool validou { get; set; }
    }
}
