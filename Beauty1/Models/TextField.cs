using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("TextField")]
public partial class TextField
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("TextField")]
    public virtual FormComponentTemplate IdNavigation { get; set; } = null!;
}
