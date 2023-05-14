using System;
using System.Collections.Generic;

namespace Plogg_API.Models.DbModels;

public partial class Rate
{
    public Guid RateId { get; set; }

    public Guid ServiceId { get; set; }

    public decimal HourlyRate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime DateCreated { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime DateModified { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User ModifiedByNavigation { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
