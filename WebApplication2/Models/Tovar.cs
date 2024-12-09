using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Tovar
{
    public long Id { get; set; }

    public string Structure { get; set; } = null!;

    public int Price { get; set; }

    public virtual ICollection<Catalogue> Catalogues { get; set; } = new List<Catalogue>();

    public virtual ICollection<Zakaz> Zakazs { get; set; } = new List<Zakaz>();
}
