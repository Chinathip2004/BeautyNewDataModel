using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("ButtonComponent")]
public partial class ButtonComponent
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("ButtonComponent")]
    public virtual Component IdNavigation { get; set; } = null!;
}
