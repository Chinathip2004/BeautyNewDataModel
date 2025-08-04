using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("ImageUpload")]
public partial class ImageUpload
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("ImageUpload")]
    public virtual FormComponentTemplate IdNavigation { get; set; } = null!;
}
