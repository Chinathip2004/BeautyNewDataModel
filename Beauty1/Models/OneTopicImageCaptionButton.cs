using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("OneTopicImageCaptionButton")]
public partial class OneTopicImageCaptionButton
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("OneTopicImageCaptionButton")]
    public virtual Component IdNavigation { get; set; } = null!;
}
