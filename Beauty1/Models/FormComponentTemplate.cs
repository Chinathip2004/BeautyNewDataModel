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

    [InverseProperty("IdNavigation")]
    public virtual BirthDate? BirthDate { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual ButtonForm? ButtonForm { get; set; }

    [InverseProperty("FormComponent")]
    public virtual ICollection<CombineFormElementTemplate> CombineFormElementTemplates { get; set; } = new List<CombineFormElementTemplate>();

    [InverseProperty("IdNavigation")]
    public virtual Date? Date { get; set; }

    [ForeignKey("FormId")]
    [InverseProperty("FormComponentTemplates")]
    public virtual FormTemplate? Form { get; set; }

    [InverseProperty("FormComponentTemplate")]
    public virtual ICollection<FormComponent> FormComponents { get; set; } = new List<FormComponent>();

    [InverseProperty("IdNavigation")]
    public virtual ImageUpload? ImageUpload { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual ImageUploadWithImageContent? ImageUploadWithImageContent { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual PopUpForm? PopUpForm { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual SingleSelection? SingleSelection { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual TextField? TextField { get; set; }
}
