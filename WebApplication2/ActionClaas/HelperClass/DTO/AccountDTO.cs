using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ActionClaas.HelperClass.DTO
{
    public class AccountDTO
    {
        public long Id { get; set; }

        public string Login { get; set; } = null!;

        public int Password { get; set; }

        public long BasketId { get; set; }

        public long ZakazId { get; set; }

        public long CatalogueId { get; set; }
    }
}
