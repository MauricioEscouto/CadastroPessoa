using Web.Shared.Enum;

namespace Web.Shared.Entities
{
    public class ContatoEntity
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Informacao { get; set; }
        public EnumTipoContato TipoContato { get; set; }
    }
}
