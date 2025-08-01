using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("TwoTopicImageCaptionButton")]
public partial class TwoTopicImageCaptionButton
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("TwoTopicImageCaptionButton")]
    public virtual Component IdNavigation { get; set; } = null!;
}
