using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public class employee
    {
        [Key]
        public int eId { get; set; }

        public string eName { get; set; }

        public int salary { get; set; }
    }
}
