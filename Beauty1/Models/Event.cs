using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("Event")]
public partial class Event
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool? IsFavorite { get; set; }

    public int? FileId { get; set; }

    [InverseProperty("Event")]
    public virtual ICollection<EventCategorize> EventCategorizes { get; set; } = new List<EventCategorize>();

    [InverseProperty("Event")]
    public virtual ICollection<Page> Pages { get; set; } = new List<Page>();
}
