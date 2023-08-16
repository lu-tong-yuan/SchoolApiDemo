using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SchoolApiDemo.Models;

public partial class Student
{
    public int StudentID { get; set; }

    public string StudentName { get; set; } = null!;

    public string StudentBirth { get; set; } = null!;

    public string StudentSex { get; set; } = null!;

    public virtual ICollection<Score> Score { get; set; } = new List<Score>();

}
