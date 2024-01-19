using Web.Shared.Entities.Abstractions;
using Web.Shared.Enum;

namespace Web.Shared.Entities
{
    public class PessoaFisicaEntity : IPessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public EnumTipoDocumento TipoDocumento { get; set; }
        public string Documento { get; set; }
        public DateTime DataNascimento { get; set; }
        public string RG { get; set; }
        public List<EnderecoEntity> Enderecos { get; set; }
        public List<ContatoEntity> Contatos { get; set; }

        public PessoaFisicaEntity()
        {
            Enderecos = new List<EnderecoEntity>();
            Contatos = new List<ContatoEntity>();
        }
    }
}
