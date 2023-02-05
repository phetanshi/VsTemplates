using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PsTest.Data.DbModels
{
    [Table("tblStudentSubjectMappings")]
    public class StudentSubjectMapping
    {
        public int StudId { get; set; }
        public int SubId { get; set; }
        public string Message { get; set; }
    }
}
