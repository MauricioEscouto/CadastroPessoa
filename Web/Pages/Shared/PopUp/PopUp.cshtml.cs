using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Shared.Entities;
using Web.Shared.Enum;

namespace Web.Pages.Shared.PopUp
{
    public class PopUpModel : PageModel
    {
        [BindProperty]
        public PopUpEntity PopUp { get; set; }

        public void OnGet(string mensagem, EnumTipoPopUp tipoPopUp)
        {
            this.PopUp = new PopUpEntity 
            { 
                Mensagem = mensagem, 
                TipoPopUp = tipoPopUp 
            };
        }
    }
}