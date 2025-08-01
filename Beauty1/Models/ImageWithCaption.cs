using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("ImageWithCaption")]
public partial class ImageWithCaption
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("ImageWithCaption")]
    public virtual Component IdNavigation { get; set; } = null!;
}
