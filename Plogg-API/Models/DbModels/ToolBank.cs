using System;
using System.Collections.Generic;

namespace Plogg_API.Models.DbModels;

public partial class ToolBank
{
    public Guid ToolId { get; set; }

    public Guid ToolName { get; set; }

    public int Quantity { get; set; }

    public decimal MarketValueAvg { get; set; }

    public bool IsAvailable { get; set; }

    public int QuantityAvailable { get; set; }

    public int QuantityLent { get; set; }

    public Guid? ServiceProviderCurrentlyWith { get; set; }

    public bool? IsLent { get; set; }

    public DateTime? DateLent { get; set; }

    public bool? IsReturned { get; set; }

    public DateTime? DateReturned { get; set; }

    public DateTime DateCreated { get; set; }

    public virtual User? ServiceProviderCurrentlyWithNavigation { get; set; }
}
