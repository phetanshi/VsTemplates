using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PsTest.Data.DbModels
{
    [Table("tblSubjects")]
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
