using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Pay
{
    public long Id { get; set; }

    public long PaymentTypeId { get; set; }

    public long ClientId { get; set; }

    public long ZakazId { get; set; }

    public int Sum { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual PaymentType PaymentType { get; set; } = null!;

    public virtual Zakaz Zakaz { get; set; } = null!;
}
