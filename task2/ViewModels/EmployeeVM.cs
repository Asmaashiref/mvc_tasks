using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using task2.servervalidation;


namespace task2.ViewModels
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Required]
        [Unique]
        [Length(3, 10,ErrorMessage = "Fname must be 3 up to 10 character")]
        public string? fname { get; set; }
        [Required]
        [Length(3, 10, ErrorMessage = "Fname must be 3 up to 10 character")]
        public string? lname { get; set; }
        
        [Required (ErrorMessage = "Required")]
        public DateOnly? bdate { get; set; }
        [Required]
        [Remote("adress", "Remote", ErrorMessage = "Address must be Cairo or Alex or Giza")]

        //[RegularExpression("^(Alex|Cairo|Giza)$")]
        public string? address { get; set; }
        [Required]
        [Column(TypeName = "money")]
        [Range(1000,12000,ErrorMessage ="Salary must be in range 1000 and 12,000")]
        public decimal? salary { get; set; }
        [Required]

        [Compare("Confirmpassword",ErrorMessage ="password doesn't match")]
        public string? password { get; set; }
        [Required]
        [Compare("password", ErrorMessage = "password doesn't match")]
        public string? Confirmpassword { get; set; }
      
        [Required(ErrorMessage = "Required")]
        public string? Sex { get; set; }

        [Required(ErrorMessage = "Required")]
        public int? dno { get; set; }

        [ValidateNever]
        public SelectList departments { get; set; }

    }
}
