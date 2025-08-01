using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("CombineFormElementTemplate")]
public partial class CombineFormElementTemplate
{
    [Key]
    public int Id { get; set; }

    public int? FormComponentId { get; set; }

    public int? FormElementId { get; set; }

    [ForeignKey("FormComponentId")]
    [InverseProperty("CombineFormElementTemplates")]
    public virtual FormComponentTemplate? FormComponent { get; set; }

    [ForeignKey("FormElementId")]
    [InverseProperty("CombineFormElementTemplates")]
    public virtual FormElementTemplate? FormElement { get; set; }
}
