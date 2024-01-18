using Api.Shared.Entities.Abstractions;
using Api.Shared.Enum;

namespace Api.Shared.Entities
{
    public class PessoaFisica : IPessoa
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get ; set ; }
        public EnumTipoDocumento TipoDocumento { get ; set ; }
        public string Documento { get ; set ; }
        public DateTime DataNascimento { get; set; }
        public string RG { get; set; }
        public List<Endereco> Enderecos { get ; set ; }
        public List<Contato> Contatos { get ; set ; }
    }
}