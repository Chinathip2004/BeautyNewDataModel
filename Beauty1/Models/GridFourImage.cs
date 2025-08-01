using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("GridFourImage")]
public partial class GridFourImage
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("GridFourImage")]
    public virtual Component IdNavigation { get; set; } = null!;
}
