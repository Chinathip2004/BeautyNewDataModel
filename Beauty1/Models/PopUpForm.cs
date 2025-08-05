using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("PopUpForm")]
public partial class PopUpForm
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("PopUpForm")]
    public virtual FormComponentTemplate IdNavigation { get; set; } = null!;
}
