using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Shared.Domain;

namespace Web.Pages.Pessoa
{
    public class PessoaFisicaModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (Sessao.Get())
            {
                return Page();
            }
            else
            {
                return RedirectToPage("/Usuario/Login");
            }
        }
    }
}
