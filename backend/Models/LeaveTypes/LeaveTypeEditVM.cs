using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.LeaveTypes
{
    public class LeaveTypeEditVM: BaseLeaveTypeVM
    {
        [Required(ErrorMessage = "Το όνομα της άδειας είναι υποχρεωτικό.", AllowEmptyStrings = false)]
        [Length(4, 150, ErrorMessage = "Το μήκος πρέπει να είναι από 4 εώς 150 χαρακτήρες.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ο αριθμός ημερών είναι υποχρεωτικός.")]
        [Range(1, 90, ErrorMessage = "Οι αριθμός ημερών πρέπει να είναι από 1 εώς 90.")]
        public int NumberOfDays { get; set; }
    }
}