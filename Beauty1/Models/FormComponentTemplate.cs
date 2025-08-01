using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("FormComponentTemplate")]
public partial class FormComponentTemplate
{
    [Key]
    public int Id { get; set; }

    public int? FormId { get; set; }

    public string? TypeName { get; set; }

    [InverseProperty("FormComponent")]
    public virtual ICollection<CombineFormElementTemplate> CombineFormElementTemplates { get; set; } = new List<CombineFormElementTemplate>();

    [ForeignKey("FormId")]
    [InverseProperty("FormComponentTemplates")]
    public virtual FormTemplate? Form { get; set; }
}
