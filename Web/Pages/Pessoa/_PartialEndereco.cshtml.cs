using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Pessoa
{
    public class _PartialEnderecoModel : PageModel
    {
        public int Id { get; set; }

        public void OnGet(int id)
        {
            Id = id;
        }
    }
}
