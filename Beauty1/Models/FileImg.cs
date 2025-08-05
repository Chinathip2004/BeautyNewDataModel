using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("FileImg")]
public partial class FileImg
{
    [Key]
    public int Id { get; set; }

    public string? FilePath { get; set; }

    public string? FileName { get; set; }

    [InverseProperty("File")]
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    [InverseProperty("File")]
    public virtual ICollection<PictureTemplate> PictureTemplates { get; set; } = new List<PictureTemplate>();

    [InverseProperty("Image")]
    public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();
}
