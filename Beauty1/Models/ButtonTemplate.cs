using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("ButtonTemplate")]
public partial class ButtonTemplate
{
    [Key]
    public int Id { get; set; }

    public string? ButtonName { get; set; }

    public string? ButtonUrl { get; set; }

    [Column("isActive")]
    public bool IsActive { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("ButtonTemplate")]
    public virtual FormElementTemplate IdNavigation { get; set; } = null!;
}
