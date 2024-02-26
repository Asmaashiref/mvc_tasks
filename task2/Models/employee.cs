using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task2.Models
{
    public class employee
    {
        [Key]
        public int Id { get; set; }
        public string? fname { get; set; }
        public string? lname { get; set; }
        public DateOnly? bdate { get; set; }
        public string? address { get; set; }
        [Column(TypeName ="money")]
        public decimal? salary { get; set; }
        public string? password { get; set; }

        public string? Sex { get; set; }

        [ForeignKey("manager")]
        public int? superssn { get; set; }

        [ForeignKey("Department")]
        public int? dno { get; set; }

        public virtual department Department { get; set; }

        public virtual department manageDepartment { get; set; }


        public virtual List<works_for> Works_Fors { get; set; } = new List<works_for>();

        public virtual employee manager { get; set; }

        [InverseProperty("manager")]
        public virtual List<employee> group { get; set; }

        public virtual List<dependant> Dependants { get; set; } = new List<dependant>();
    }
}
