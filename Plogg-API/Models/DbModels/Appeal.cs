using System;
using System.Collections.Generic;

namespace Plogg_API.Models.DbModels;

public partial class Appeal
{
    public Guid AppealId { get; set; }

    public Guid AppealedBy { get; set; }

    public Guid AppealReasonId { get; set; }

    public string AppealDescription { get; set; } = null!;

    public Guid AppealFor { get; set; }

    public Guid TaskId { get; set; }

    public bool? IsResolved { get; set; }

    public DateTime? DateResolved { get; set; }

    public DateTime DateCreated { get; set; }

    public Guid CreatedBy { get; set; }

    public virtual User AppealForNavigation { get; set; } = null!;

    public virtual AppealReason AppealReason { get; set; } = null!;

    public virtual User AppealedByNavigation { get; set; } = null!;

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
