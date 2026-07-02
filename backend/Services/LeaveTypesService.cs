using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models.LeaveTypes;
using LeaveManagementSystem.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class LeaveTypesService(ApplicationDbContext context): ILeaveTypesSevice
    {
        public async Task<List<LeaveTypeReadOnlyVM>> GetAll()
        {
            var leaveTypes = await context.LeaveTypes.Select(item => new LeaveTypeReadOnlyVM
            {
                Id = item.Id,
                Name = item.Name,
                NumberOfDays = item.NumberOfDays
            }).ToListAsync();

            return leaveTypes;
        }

        public async Task<LeaveTypeReadOnlyVM?> Get(int? id) {
            var leaveTypeEntity = await context.LeaveTypes.FindAsync(id);

            if(leaveTypeEntity == null) return null;

            var leaveType = new LeaveTypeReadOnlyVM
            {
                Id = leaveTypeEntity.Id,
                Name = leaveTypeEntity.Name,
                NumberOfDays = leaveTypeEntity.NumberOfDays
            };

            return leaveType;
        }

        public async Task<LeaveTypeReadOnlyVM> Create(LeaveTypeCreateVM leaveTypeCreate)
        {
            var exists = await context.LeaveTypes.AnyAsync(q => q.Name == leaveTypeCreate.Name);

            if (exists)
            {
                throw new InvalidOperationException("Η συγκεκριμένη άδεια υπάρχει ήδη στη βάση δεδομένων.");
            }

            var leaveType = new LeaveType
            {
                Name = leaveTypeCreate.Name,
                NumberOfDays = leaveTypeCreate.NumberOfDays
            };

            context.LeaveTypes.Add(leaveType);

            await context.SaveChangesAsync();

            return new LeaveTypeReadOnlyVM
            {
                Id = leaveType.Id,
                Name = leaveType.Name,
                NumberOfDays = leaveType.NumberOfDays
            };
        }

        public async Task<bool> Update(int id, LeaveTypeEditVM leaveTypeEdit)
        {
            var exists = await context.LeaveTypes.AnyAsync(q => q.Name == leaveTypeEdit.Name && q.Id != id);

            if (exists)
            {
                throw new InvalidOperationException("Η συγκεκριμένη άδεια υπάρχει ήδη στη βάση δεδομένων.");
            }

            var leaveTypeEntity = await context.LeaveTypes.FindAsync(id);

            if(leaveTypeEntity == null)
            {
                return false;
            }

            leaveTypeEntity.Name = leaveTypeEdit.Name;
            leaveTypeEntity.NumberOfDays = leaveTypeEdit.NumberOfDays;

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Remove(int id)
        {
            var leaveType = await context.LeaveTypes.FindAsync(id);

            if(leaveType == null)
            {
                return false;
            }
        
            context.LeaveTypes.Remove(leaveType);

            await context.SaveChangesAsync();

            return true;
        }
    }
}