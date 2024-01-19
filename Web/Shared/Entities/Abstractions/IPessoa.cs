using Web.Shared.Enum;

namespace Web.Shared.Entities.Abstractions
{
    public interface IPessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public EnumTipoDocumento TipoDocumento { get; set; }
        public string Documento { get; set; }
        public List<EnderecoEntity> Enderecos { get; set; }
        public List<ContatoEntity> Contatos { get; set; }
    }
}
