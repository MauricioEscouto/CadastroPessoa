using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Shared.Domain;

namespace Web.Pages.Usuario
{
    public class CadastroModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (Sessao.Get())
            {
                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
