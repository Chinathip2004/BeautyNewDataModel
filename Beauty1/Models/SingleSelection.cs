using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("SingleSelection")]
public partial class SingleSelection
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("SingleSelection")]
    public virtual FormComponentTemplate IdNavigation { get; set; } = null!;
}
