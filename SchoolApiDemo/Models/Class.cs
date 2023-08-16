using System;
using System.Collections.Generic;

namespace SchoolApiDemo.Models;

public partial class Class
{
    public int ClassID { get; set; }

    public string ClassName { get; set; } = null!;

    public int TeacherID { get; set; }

    public virtual ICollection<Score> Score { get; set; } = new List<Score>();
}
