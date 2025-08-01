using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("CombineElement")]
public partial class CombineElement
{
    [Key]
    public int Id { get; set; }

    public int? ComponentId { get; set; }

    public int? ComponentElementId { get; set; }

    [ForeignKey("ComponentId")]
    [InverseProperty("CombineElements")]
    public virtual Component? Component { get; set; }

    [ForeignKey("ComponentElementId")]
    [InverseProperty("CombineElements")]
    public virtual ComponentElement? ComponentElement { get; set; }
}
