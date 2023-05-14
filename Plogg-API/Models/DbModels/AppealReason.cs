using System;
using System.Collections.Generic;

namespace Plogg_API.Models.DbModels;

public partial class AppealReason
{
    public Guid AppealReasonId { get; set; }

    public string AppealReason1 { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public Guid CreatedBy { get; set; }

    public virtual ICollection<Appeal> Appeals { get; set; } = new List<Appeal>();

    public virtual User CreatedByNavigation { get; set; } = null!;
}
