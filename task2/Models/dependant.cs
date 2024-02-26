namespace task2.Models
{
    public class dependant
    {
        public int essn { get; set; }
        public string dependant_name { get; set;}
        public string? sex { get; set;}
        public DateOnly bdate { get;set;}

        public virtual employee Employee { get; set; }
    }
}
