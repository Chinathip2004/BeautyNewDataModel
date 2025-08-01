using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("Containing")]
public partial class Containing
{
    [Key]
    public int Id { get; set; }

    public int? ContainerId { get; set; }

    public int? ComponentId { get; set; }

    public int? Order { get; set; }

    public bool? IsShow { get; set; }

    [ForeignKey("ComponentId")]
    [InverseProperty("Containings")]
    public virtual Component? Component { get; set; }

    [ForeignKey("ContainerId")]
    [InverseProperty("Containings")]
    public virtual Container? Container { get; set; }
}
