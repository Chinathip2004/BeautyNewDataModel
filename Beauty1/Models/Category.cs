using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("Category")]
public partial class Category
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<EventCategorize> EventCategorizes { get; set; } = new List<EventCategorize>();
}
