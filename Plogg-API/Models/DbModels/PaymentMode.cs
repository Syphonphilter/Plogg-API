using System;
using System.Collections.Generic;

namespace Plogg_API.Models.DbModels;

public partial class PaymentMode
{
    public Guid PaymentModeId { get; set; }

    public string PaymentMode1 { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Tip> Tips { get; set; } = new List<Tip>();

    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();
}
