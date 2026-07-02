using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.LeaveTypes
{
    public class LeaveTypeReadOnlyVM : BaseLeaveTypeVM
    {   
        public string Name { get; set; } = string.Empty;

        public int NumberOfDays { get; set; }
    }
}