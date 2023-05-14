using System;
using System.Collections.Generic;

namespace Plogg_API.Models.DbModels;

public partial class Service
{
    public Guid ServiceId { get; set; }

    public string ServiceName { get; set; } = null!;

    public Guid ServiceTypeId { get; set; }

    public Guid ServiceCategoryId { get; set; }

    public DateTime DateCreated { get; set; }

    public Guid CreatedBy { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime DateModified { get; set; }

    public bool IsDeleted { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User ModifiedByNavigation { get; set; } = null!;

    public virtual ICollection<Rate> Rates { get; set; } = new List<Rate>();

    public virtual ServiceCategory ServiceCategory { get; set; } = null!;

    public virtual ServiceType ServiceType { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
