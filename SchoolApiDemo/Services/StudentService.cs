using Microsoft.EntityFrameworkCore;
using SchoolApiDemo.Dtos;
using SchoolApiDemo.Models;

namespace SchoolApiDemo.Services
{
    public class StudentService
    {
        private readonly SchoolContext _schoolContext;

        public StudentService(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public List<StudentDto> GetStudentList()
        {
            var result = _schoolContext.Student.Include(a => a.Score).ThenInclude(b => b.Class).ToList();

            return result.Select(a => ItemToDto(a)).ToList();
        }

        public StudentDto GetStudent(int id)
        {
            var result = (from a in _schoolContext.Student
                          where a.StudentID == id
                          select a).Include(a => a.Score).ThenInclude(b => b.Class).SingleOrDefault();
            if (result != null)
            {
                return ItemToDto(result);
            }

            return null;
        }

        public Student PostStudent(StudentPostDto value) 
        {
            Student insert = new Student();
            _schoolContext.Student.Add(insert).CurrentValues.SetValues(value);
            _schoolContext.SaveChanges();

            return insert;
        }

        public int PutStudent(int id, StudentPutDto value)
        {
            var update = (from a in _schoolContext.Student
                          where a.StudentID == id
                          select a).SingleOrDefault();

            if (update != null)
            {
                _schoolContext.Student.Update(update).CurrentValues.SetValues(value);
            }

            return _schoolContext.SaveChanges();
        }

        public int DeleteStudent(int id)
        {
            var delete = (from a in _schoolContext.Student
                          where a.StudentID == id
                          select a).Include(b => b.Score).SingleOrDefault();

            if (delete != null)
            {
                _schoolContext.Student.Remove(delete);
            }

            return _schoolContext.SaveChanges();
        }

        private static StudentDto ItemToDto(Student a)
        {
            List<ScoreDto> scdto = new List<ScoreDto>();

            foreach (var temp in a.Score)
            {
                ScoreDto sc = new ScoreDto
                {
                    ScoreID = temp.ScoreID,
                    StudentID = temp.StudentID,
                    StudentScore = temp.StudentScore,
                    ClassName = temp.Class.ClassName
                };
                scdto.Add(sc);

            }
            return new StudentDto
            {
                StudentID = a.StudentID,
                StudentName = a.StudentName,
                StudentBirth = a.StudentBirth,
                StudentSex = a.StudentSex,
                Scores = scdto
            };
        }
    }
}
