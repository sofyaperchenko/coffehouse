using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ActionClaas.Account
{
    public class AccountCreate
    {
        [Required]

        public long Id { get; set; }
        [Required]
        public string Login { get; set; } = null!;
        [Required]
        public int Password { get; set; }
        [Required]
        public long BasketId { get; set; }
        [Required]
        public long ZakazId { get; set; }
        [Required]
        public long CatalogueId { get; set; }

    }
}

