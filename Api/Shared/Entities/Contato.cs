using Api.Shared.Enum;

namespace Api.Shared.Entities
{
    public class Contato
    {
        public string Nome { get; set; }
        public string Informacao { get; set; }
        public EnumTipoContato TipoContato { get; set; }    
    }
}
