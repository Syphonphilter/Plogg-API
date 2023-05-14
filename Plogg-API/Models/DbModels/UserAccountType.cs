using System;
using System.Collections.Generic;

namespace Plogg_API.Models.DbModels;

public partial class UserAccountType
{
    public Guid UserAccountTypeId { get; set; }

    public string UserAccountType1 { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public Guid CreatedBy { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime DateModified { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
