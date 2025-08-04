using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("Form")]
public partial class Form
{
    [Key]
    public int Id { get; set; }

    public int? FormTemplateId { get; set; }

    [InverseProperty("Form")]
    public virtual ICollection<FormComponent> FormComponents { get; set; } = new List<FormComponent>();

    [ForeignKey("FormTemplateId")]
    [InverseProperty("Forms")]
    public virtual FormTemplate? FormTemplate { get; set; }
}
