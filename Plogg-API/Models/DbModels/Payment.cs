using System;
using System.Collections.Generic;

namespace Plogg_API.Models.DbModels;

public partial class Payment
{
    public Guid PaymentId { get; set; }

    public Guid TaskId { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public string PaymentRef { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public Guid PaymentModeId { get; set; }

    public virtual PaymentMode PaymentMode { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
