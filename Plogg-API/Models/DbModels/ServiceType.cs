﻿using System;
using System.Collections.Generic;

namespace Plogg_API.Models.DbModels;

public partial class ServiceType
{
    public Guid ServiceTypeId { get; set; }

    public string ServiceType1 { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public Guid CreatedBy { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime DateModified { get; set; }

    public bool IsDeleted { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User ModifiedByNavigation { get; set; } = null!;

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
