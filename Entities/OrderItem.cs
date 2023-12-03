using System;
using System.Collections.Generic;

namespace Entities;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int? ProductsId { get; set; }

    public int? OrderId { get; set; }

    public int? Ouantity { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
