using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Data
{
    public class LeaveType
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        public int NumberOfDays { get; set; }
    }
}