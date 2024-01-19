using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Shared.Utilities;

namespace Web.Pages.Pessoa
{
    public class _PartialEnderecoModel : PageModel
    {
        public int Id { get; set; }
        [BindProperty]
        public List<string> Estados { get; set; }

        public void OnGet(int id)
        {
            Estados = EstadosBrasil.ObterEstadosAbreviados();
            Id = id;
        }
    }
}