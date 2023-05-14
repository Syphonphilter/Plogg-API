using System;
using System.Collections.Generic;

namespace Plogg_API.Models.DbModels;

public partial class Rating
{
    public Guid RatingId { get; set; }

    public int Rating1 { get; set; }

    public string RatingDescription { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
