using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task2.Models
{
    public class project
    {
        [Key]
        public int Id { get; set; }
        public string pname { get; set; }
        public string? plocation { get; set; }
        public string? city { get; set; }

        [ForeignKey("Department")]
        public int dnum { get; set; }

        public virtual department Department { get; set; }

        public virtual List<works_for> Works_Fors { get; set; } = new List<works_for>();


    }
}
