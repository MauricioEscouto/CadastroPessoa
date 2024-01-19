using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Shared.Domain;

namespace Web.Pages.Pessoa
{
    public class PessoaModel : PageModel
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
