namespace SchoolApiDemo.Dtos
{
    public class StudentDto
    {
        public int StudentID { get; set; }

        public string StudentName { get; set; } = null!;

        public string StudentBirth { get; set; } = null!;

        public string StudentSex { get; set; } = null!;

        public List<ScoreDto> Scores { get; set; }
    }
}
