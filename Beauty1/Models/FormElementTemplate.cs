using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("FormElementTemplate")]
public partial class FormElementTemplate
{
    [Key]
    public int Id { get; set; }

    public string? Type { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual ButtonTemplate? ButtonTemplate { get; set; }

    [InverseProperty("FormElement")]
    public virtual ICollection<CombineFormElementTemplate> CombineFormElementTemplates { get; set; } = new List<CombineFormElementTemplate>();

    [InverseProperty("FormElementTemplate")]
    public virtual ICollection<FormElement> FormElements { get; set; } = new List<FormElement>();

    [InverseProperty("IdNavigation")]
    public virtual FormInputDateTemplate? FormInputDateTemplate { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual FormInputFileTemplate? FormInputFileTemplate { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual FormInputTextTemplate? FormInputTextTemplate { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual FormLabelTemplate? FormLabelTemplate { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual FormOptionTemplate? FormOptionTemplate { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual PictureTemplate? PictureTemplate { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual PopUpTemplate? PopUpTemplate { get; set; }
}
