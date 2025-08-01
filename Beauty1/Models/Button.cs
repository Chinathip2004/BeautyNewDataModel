using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("Button")]
public partial class Button
{
    [Key]
    public int Id { get; set; }

    public string? ButtonText { get; set; }

    public string? ButtonUrl { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("Button")]
    public virtual ComponentElement IdNavigation { get; set; } = null!;
}
