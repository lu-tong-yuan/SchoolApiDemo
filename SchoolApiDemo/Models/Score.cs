using System;
using System.Collections.Generic;

namespace SchoolApiDemo.Models;

public partial class Score
{
    public int ScoreID { get; set; }

    public int StudentID { get; set; }

    public int ClassID { get; set; }

    public string StudentScore { get; set; } = null!;

    public virtual Class Class { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
