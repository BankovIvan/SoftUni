namespace MiniORMApp.DATA.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class EmployeeProject
    {
        [Key]
        [ForeignKey(nameof(Employee))]

        public int EmployeeId { get; set; }

        [Key]
        [ForeignKey(nameof(Project))]

        public int ProjectId { get; set; }

        public Employee Employee { get; set; }

        public Project Project { get; set; }
    }
}
