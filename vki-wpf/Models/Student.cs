using System;
using System.Collections.Generic;

namespace vki_wpf.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public int GroupId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Group Group { get; set; } = null!;
}
