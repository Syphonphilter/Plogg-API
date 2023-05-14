using System;
using System.Collections.Generic;

namespace Plogg_API.Models.DbModels;

public partial class ToolInventory
{
    public Guid ToolId { get; set; }

    public Guid VendorId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual Tool Tool { get; set; } = null!;

    public virtual Vendor Vendor { get; set; } = null!;
}
