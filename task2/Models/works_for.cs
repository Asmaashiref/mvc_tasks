using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace task2.Models
{
    [PrimaryKey("essn", "pnum")]
    public class works_for
    {
        [ForeignKey("Employee")]
        public int essn { get; set; }

        [ForeignKey("Project")]
        public int pnum { get; set;}
        public int houres { get; set;}

        public virtual project Project { get; set; }

        public virtual employee Employee { get; set; }


    }
}
