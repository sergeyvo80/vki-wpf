using System;
using System.Collections.Generic;

namespace vki_wpf.Models;

public partial class Group
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
