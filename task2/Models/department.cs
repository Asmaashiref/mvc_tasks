using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task2.Models
{
    public class department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [ForeignKey("managr")]
        public int? MGRssn { get; set; }
        public DateOnly? startdate { get; set; }

        [InverseProperty("manageDepartment")]
        public virtual employee managr { get; set; }

        [InverseProperty("Department")]
        public virtual List<employee> Employees { get; set; } = new List<employee>();

        public virtual List<project> Projects { get; set; } = new List<project>();



    }
}
