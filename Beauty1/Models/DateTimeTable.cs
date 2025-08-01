using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("DateTimeTable")]
public partial class DateTimeTable
{
    [Key]
    public int Id { get; set; }

    public string? DateTimeValue { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("DateTimeTable")]
    public virtual ComponentElement IdNavigation { get; set; } = null!;
}
