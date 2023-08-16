using System;
using System.Collections.Generic;

namespace SchoolApiDemo.Models;

public partial class Teacher
{
    public int TeacherID { get; set; }

    public string TeacherName { get; set; } = null!;

    public string TeacherSex { get; set; } = null!;
}
