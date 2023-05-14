using System;
using System.Collections.Generic;

namespace Plogg_API.Models.DbModels;

public partial class ToolCategory
{
    public Guid CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Tool> Tools { get; set; } = new List<Tool>();
}
