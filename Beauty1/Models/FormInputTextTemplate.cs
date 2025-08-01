using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("FormInputTextTemplate")]
public partial class FormInputTextTemplate
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("FormInputTextTemplate")]
    public virtual FormElementTemplate IdNavigation { get; set; } = null!;
}
