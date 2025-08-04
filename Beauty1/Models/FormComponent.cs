using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("FormComponent")]
public partial class FormComponent
{
    [Key]
    public int Id { get; set; }

    public int? FormId { get; set; }

    public int? FormComponentTemplateId { get; set; }

    [ForeignKey("FormId")]
    [InverseProperty("FormComponents")]
    public virtual Form? Form { get; set; }

    [InverseProperty("FormComponent")]
    public virtual ICollection<FormCombineElement> FormCombineElements { get; set; } = new List<FormCombineElement>();

    [ForeignKey("FormComponentTemplateId")]
    [InverseProperty("FormComponents")]
    public virtual FormComponentTemplate? FormComponentTemplate { get; set; }
}
