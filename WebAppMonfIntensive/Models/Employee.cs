using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMonfIntensive.Models
{
    public class Employee
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Name Is Required")]
        [MinLength(3,ErrorMessage ="Name Must be More Than 2 Char")]
        [MaxLength(25)]
        public string Name { get; set; }
        
        public string? Email { get; set; }

        [Range(6000,50000)]
        public int Salary { get; set; }

        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="Image Must Be jpg or png")]//christen.png
        public string? ImageUrl { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        //[Required] not allow null
        public Department? Department { get; set; }
    }
}
