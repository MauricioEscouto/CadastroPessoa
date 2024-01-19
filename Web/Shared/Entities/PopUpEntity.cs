using Web.Shared.Enum;

namespace Web.Shared.Entities
{
    public class PopUpEntity
    {
        public string? Mensagem { get; set; }
        public EnumTipoPopUp TipoPopUp { get; set; }

        public PopUpEntity() { }
    }
}