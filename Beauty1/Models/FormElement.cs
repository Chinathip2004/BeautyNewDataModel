using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("FormElement")]
public partial class FormElement
{
    [Key]
    public int Id { get; set; }

    public int? FormElementTemplateId { get; set; }

    [InverseProperty("FormElement")]
    public virtual ICollection<FormCombineElement> FormCombineElements { get; set; } = new List<FormCombineElement>();

    [ForeignKey("FormElementTemplateId")]
    [InverseProperty("FormElements")]
    public virtual FormElementTemplate? FormElementTemplate { get; set; }
}
