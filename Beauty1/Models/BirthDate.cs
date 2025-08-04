using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("BirthDate")]
public partial class BirthDate
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("BirthDate")]
    public virtual FormComponentTemplate IdNavigation { get; set; } = null!;
}
