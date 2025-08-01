using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("NumberTable")]
public partial class NumberTable
{
    [Key]
    public int Id { get; set; }

    public string? NumberValue { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("NumberTable")]
    public virtual ComponentElement IdNavigation { get; set; } = null!;
}
