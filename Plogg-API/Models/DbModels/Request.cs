using System;
using System.Collections.Generic;

namespace Plogg_API.Models.DbModels;

public partial class Request
{
    public Guid RequestId { get; set; }

    public Guid UserId { get; set; }

    public Guid ServiceSubCategoryId { get; set; }

    public DateTime? DateCreated { get; set; }

    public bool IsAccpted { get; set; }

    public Guid? AcceptedBy { get; set; }

    public DateTime? DateAccepted { get; set; }

    public bool HasVendor { get; set; }

    public Guid? VendorId { get; set; }

    public bool VendorAccepted { get; set; }

    public DateTime? DateVendorAccepted { get; set; }

    public bool IsRequestCompleted { get; set; }

    public DateTime? DateRequestCompleted { get; set; }
}
