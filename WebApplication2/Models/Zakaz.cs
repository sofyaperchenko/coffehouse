using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Zakaz
{
    public long Id { get; set; }

    public int Number { get; set; }

    public long TovarId { get; set; }

    public DateOnly DateRegestration { get; set; }

    public virtual ICollection<Pay> Pays { get; set; } = new List<Pay>();

    public virtual Tovar Tovar { get; set; } = null!;
}
