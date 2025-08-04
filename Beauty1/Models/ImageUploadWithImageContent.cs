using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("ImageUploadWithImageContent")]
public partial class ImageUploadWithImageContent
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("ImageUploadWithImageContent")]
    public virtual FormComponentTemplate IdNavigation { get; set; } = null!;
}
