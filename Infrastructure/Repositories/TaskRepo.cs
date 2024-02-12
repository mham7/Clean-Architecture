using Application.Interfaces.Repos;
using Domain.Models;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TaskRepo:GenericRepo<Tasks>,ITaskRepo
    {

        AppDbContext _context;
        public TaskRepo(AppDbContext context) : base(context)
        {
            _context = context;
            
        }

        public async Task<Tasks> Patch(int id, string details)
        {
            Tasks t = await Get(id);
            t.TaskDetail = details;
            await Put(t);
            return t;
        }

        public async Task<Tasks> Patch(int id, DateTime deadline)
        {
            Tasks t = await Get(id);
            t.Deadline = deadline;
            await Put(t);
            return t;

        }
    }
}
