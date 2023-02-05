using Microsoft.EntityFrameworkCore;
using PsTest.Data.DbModels;
using System.Xml.Linq;

namespace PsTest.UnitTest.TestHelpers
{
    public static class DBDataSets
    {
        public static List<Employee> GetEmployeeTableTestData()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { EmployeeId = 1, UserId = "CORP\\e999999", FirstName = "TestOne", LastName = "One", CreatedBy = DateTime.Now.ToString() });
            employees.Add(new Employee { EmployeeId = 2, UserId = "CORP\\e777777", FirstName = "TestTwo", LastName = "Two", CreatedBy = DateTime.Now.ToString() });
            employees.Add(new Employee { EmployeeId = 3, UserId = "CORP\\e666666", FirstName = "TestThree", LastName = "Three", CreatedBy = DateTime.Now.ToString() });

            return employees;
        }
        public static List<Student> GetStudentTestData()
        {
            List<Student> data = new List<Student>();
            data.Add(new Student { Id = 1, Name = "StudOne" });
            data.Add(new Student { Id = 2, Name = "StudTwo" });
            data.Add(new Student { Id = 3, Name = "StudThree" });
            return data;
        }

        public static List<Subject> GetSubjectTestData()
        {
            List<Subject> data = new List<Subject>();
            data.Add(new Subject { Id = 1, Name = "SubjectOne" });
            data.Add(new Subject { Id = 2, Name = "SubjectTwo" });
            data.Add(new Subject { Id = 3, Name = "SubjectThree" });
            return data;
        }

        public static List<StudentSubjectMapping> GetStudentSubjectMappingTestData()
        {
            List<StudentSubjectMapping> data = new List<StudentSubjectMapping>();
            data.Add(new StudentSubjectMapping { StudId = 1, SubId = 1, Message = "One One" });
            data.Add(new StudentSubjectMapping { StudId = 1, SubId = 2, Message = "One Two" });

            data.Add(new StudentSubjectMapping { StudId = 2, SubId = 2, Message = "Two Two" });
            data.Add(new StudentSubjectMapping { StudId = 2, SubId = 3, Message = "Two Three" });

            data.Add(new StudentSubjectMapping { StudId = 3, SubId = 1, Message = "Three One" });
            data.Add(new StudentSubjectMapping { StudId = 3, SubId = 3, Message = "Three Three" });
            return data;
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(GetEmployeeTableTestData());
            modelBuilder.Entity<Student>().HasData(GetStudentTestData());
            modelBuilder.Entity<Subject>().HasData(GetSubjectTestData());
            modelBuilder.Entity<StudentSubjectMapping>().HasData(GetStudentSubjectMappingTestData());
        }
    }
}
