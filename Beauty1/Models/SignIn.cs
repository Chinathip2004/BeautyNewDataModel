using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

[Table("SignIn")]
public partial class SignIn
{
    [Key]
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }
}
