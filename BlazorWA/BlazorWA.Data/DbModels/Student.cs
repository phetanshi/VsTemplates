using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorWA.Data.DbModels
{
    [Table("tblStudents")]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
