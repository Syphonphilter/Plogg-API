using System;
using System.Collections.Generic;

namespace Plogg_API.Models.DbModels;

public partial class Tip
{
    public Guid TipId { get; set; }

    public Guid CustomerUserId { get; set; }

    public Guid ServiceProviderUserId { get; set; }

    public Guid ServiceId { get; set; }

    public decimal TipValue { get; set; }

    public DateTime DateCreated { get; set; }

    public Guid PaymentModeId { get; set; }

    public virtual User CustomerUser { get; set; } = null!;

    public virtual PaymentMode PaymentMode { get; set; } = null!;

    public virtual User ServiceProviderUser { get; set; } = null!;
}
