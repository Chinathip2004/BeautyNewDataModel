using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("PopUpTemplate")]
public partial class PopUpTemplate
{
    [Key]
    public int Id { get; set; }

    public string? Url { get; set; }

    public string? TextValue { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("PopUpTemplate")]
    public virtual FormElementTemplate IdNavigation { get; set; } = null!;
}
