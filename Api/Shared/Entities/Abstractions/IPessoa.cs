using Api.Shared.Enum;

namespace Api.Shared.Entities.Abstractions
{
    public interface IPessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public EnumTipoDocumento TipoDocumento { get; set; }
        public string Documento { get; set; }
        public List<Endereco> Enderecos { get; set; }
        public List<Contato> Contatos { get; set; }
    }
}
