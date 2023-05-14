using System;
using System.Collections.Generic;

namespace Plogg_API.Models.DbModels;

public partial class ServiceCategory
{
    public Guid ServiceCategoryId { get; set; }

    public string ServiceCategory1 { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public Guid CreatedBy { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime DateModified { get; set; }

    public bool IsDeleted { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User ModifiedByNavigation { get; set; } = null!;

    public virtual ICollection<ServiceSubCategory> ServiceSubCategories { get; set; } = new List<ServiceSubCategory>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
