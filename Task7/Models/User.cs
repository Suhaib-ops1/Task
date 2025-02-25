using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task7.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = null!;
    [Required]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;
}
