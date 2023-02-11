using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace $safeprojectname$.Database.Models
{
    [Table("tblErrorTypes")]
    public class ErrorType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ErrorTypeId { get; set; }
        public string ErrorTypeName { get; set; }


    }
}
