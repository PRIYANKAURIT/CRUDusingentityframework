using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace CRUDusingentityframework.Models
{
    [Table("Employeedetails")]
    public class Employee
    {
        [Key]

        public int Id { get; set; }

        public int Name { get; set; }

        public int Salary { get; set; }

    }
}
