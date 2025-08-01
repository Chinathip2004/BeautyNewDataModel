using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("FormInputDateTemplate")]
public partial class FormInputDateTemplate
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("FormInputDateTemplate")]
    public virtual FormElementTemplate IdNavigation { get; set; } = null!;
}
