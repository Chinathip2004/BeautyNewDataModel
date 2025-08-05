using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("ComponentElement")]
public partial class ComponentElement
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual Button? Button { get; set; }

    [InverseProperty("ComponentElement")]
    public virtual ICollection<CombineElement> CombineElements { get; set; } = new List<CombineElement>();

    [InverseProperty("IdNavigation")]
    public virtual DateTimeTable? DateTimeTable { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual NumberTable? NumberTable { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual Picture? Picture { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual Text? Text { get; set; }
}
