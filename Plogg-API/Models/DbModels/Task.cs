using System;
using System.Collections.Generic;

namespace Plogg_API.Models.DbModels;

public partial class Task
{
    public Guid TaskId { get; set; }

    public Guid ServiceProviderUserId { get; set; }

    public Guid CustomerUserId { get; set; }

    public Guid ServiceId { get; set; }

    public Guid LocationId { get; set; }

    public int TaskStartToken { get; set; }

    public bool IsStartTokenValidated { get; set; }

    public int HoursSpent { get; set; }

    public bool IsEndTokenValidated { get; set; }

    public int TaskEndToken { get; set; }

    public bool IsTaskCanceled { get; set; }

    public Guid? CancelationReasonId { get; set; }

    public Guid? RatingId { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime DateCreated { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<Appeal> Appeals { get; set; } = new List<Appeal>();

    public virtual CancelationReason? CancelationReason { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Rating? Rating { get; set; }

    public virtual Service Service { get; set; } = null!;

    public virtual User ServiceProviderUser { get; set; } = null!;

    public virtual Location TaskNavigation { get; set; } = null!;
}
