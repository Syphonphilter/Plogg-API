using System;
using System.Collections.Generic;

namespace Plogg_API.Models.DbModels;

public partial class CancelationReason
{
    public Guid CancelationReasonId { get; set; }

    public string? Reason { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime DateCreated { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
