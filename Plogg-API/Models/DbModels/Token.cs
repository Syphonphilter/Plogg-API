using System;
using System.Collections.Generic;

namespace Plogg_API.Models.DbModels;

public partial class Token
{
    public Guid TokenId { get; set; }

    public string TokenName { get; set; } = null!;

    public string? TokenValidationHash { get; set; }

    public DateTime DateCreated { get; set; }

    public Guid PaymentModeId { get; set; }

    public virtual PaymentMode PaymentMode { get; set; } = null!;
}
