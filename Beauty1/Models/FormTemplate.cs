using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("FormTemplate")]
public partial class FormTemplate
{
    [Key]
    public int Id { get; set; }

    [InverseProperty("Form")]
    public virtual ICollection<FormComponentTemplate> FormComponentTemplates { get; set; } = new List<FormComponentTemplate>();

    [ForeignKey("Id")]
    [InverseProperty("FormTemplate")]
    public virtual Component IdNavigation { get; set; } = null!;
}
