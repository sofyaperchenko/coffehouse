using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class PaymentType
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Pay> Pays { get; set; } = new List<Pay>();
}
