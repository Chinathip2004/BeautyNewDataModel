using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("FormCombineElement")]
public partial class FormCombineElement
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public int? FormComponentId { get; set; }

    public int? FormElementId { get; set; }

    [ForeignKey("FormComponentId")]
    [InverseProperty("FormCombineElements")]
    public virtual FormComponent? FormComponent { get; set; }

    [ForeignKey("FormElementId")]
    [InverseProperty("FormCombineElements")]
    public virtual FormElement? FormElement { get; set; }
}
