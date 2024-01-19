using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Pessoa
{
    public class _PartialContatoModel : PageModel
    {
        public int Id { get; set; }

        public void OnGet(int id)
        {
            Id = id;
        }
    }
}
