using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Catalogue
{
    public long Id { get; set; }

    public long TovarId { get; set; }

    public string Description { get; set; } = null!;

    public virtual Tovar Tovar { get; set; } = null!;
}
