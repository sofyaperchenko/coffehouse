using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Client
{
    public long Id { get; set; }

    public string Login { get; set; } = null!;

    public int Password { get; set; }

    public long BasketId { get; set; }

    public long ZakazId { get; set; }

    public long CatalogueId { get; set; }

    public virtual ICollection<Pay> Pays { get; set; } = new List<Pay>();
}
