using System;
using System.Collections.Generic;

namespace Plogg_API.Models.DbModels;

public partial class Tool
{
    public Guid ToolId { get; set; }

    public string ToolName { get; set; } = null!;

    public Guid CategoryId { get; set; }

    public virtual ToolCategory Category { get; set; } = null!;

    public virtual ICollection<ToolInventory> ToolInventories { get; set; } = new List<ToolInventory>();
}
