using System;
using System.Collections.Generic;

namespace Plogg_API.Models.DbModels;

public partial class Location
{
    public Guid LocationId { get; set; }

    public string LocationLatLong { get; set; } = null!;

    public int ZipCode { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime DateCreated { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime DateModified { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User ModifiedByNavigation { get; set; } = null!;

    public virtual Task? Task { get; set; }
}
