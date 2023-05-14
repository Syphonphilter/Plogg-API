using System;
using System.Collections.Generic;

namespace Plogg_API.Models.DbModels;

public partial class Vendor
{
    public Guid VendorId { get; set; }

    public string VendorName { get; set; } = null!;

    public string VendorRegistrationNumber { get; set; } = null!;

    public Guid UnionId { get; set; }

    public string? VendorAddress { get; set; }

    public string? Phone1 { get; set; }

    public string? Phone2 { get; set; }

    public virtual ICollection<ToolInventory> ToolInventories { get; set; } = new List<ToolInventory>();
}
