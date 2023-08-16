namespace SchoolApiDemo.Dtos
{
    public class ScoreDto
    {
        public int ScoreID { get; set; }

        public int StudentID { get; set; }

        public string ClassName { get; set; } = null!;

        public string StudentScore { get; set; } = null!;
    }
}
