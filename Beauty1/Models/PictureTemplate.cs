using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("PictureTemplate")]
public partial class PictureTemplate
{
    [Key]
    public int Id { get; set; }

    public int? FileId { get; set; }

    [ForeignKey("FileId")]
    [InverseProperty("PictureTemplates")]
    public virtual FileImg? File { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("PictureTemplate")]
    public virtual FormElementTemplate IdNavigation { get; set; } = null!;
}
