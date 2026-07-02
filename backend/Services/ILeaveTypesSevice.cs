using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models.LeaveTypes;

namespace backend.Services
{
    public interface ILeaveTypesSevice
    {
        Task<List<LeaveTypeReadOnlyVM>> GetAll();
        Task<LeaveTypeReadOnlyVM?> Get(int? id);
        Task<LeaveTypeReadOnlyVM> Create(LeaveTypeCreateVM leaveTypeCreate);
        Task<bool> Update(int id, LeaveTypeEditVM leaveTypeEdit);
        Task<bool> Remove(int id);
    }
}