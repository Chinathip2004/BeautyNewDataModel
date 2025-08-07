using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("EventCategorize")]
public partial class EventCategorize
{
    [Key]
    public int Id { get; set; }

    public int? EventId { get; set; }

    public int? CategoryId { get; set; }

    public bool? IsDelete { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("EventCategorizes")]
    public virtual Category? Category { get; set; }

    [ForeignKey("EventId")]
    [InverseProperty("EventCategorizes")]
    public virtual Event? Event { get; set; }
}
