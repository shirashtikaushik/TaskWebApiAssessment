﻿using Microsoft.EntityFrameworkCore;
using TaskWebApiAssessment.DataContext;
using TaskWebApiAssessment.ITaskRepository;

namespace TaskWebApiAssessment.Repo
{
    public class TaskRepo : ITask
    {
        TaskDbContext _context;

        public TaskRepo(TaskDbContext context)
        {
            _context = context;
        }


        public async Task<bool> AddTask(Model.Task task)
        {
            task.CreatedOn = DateTime.Now;
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteTask(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Edit(Model.Task task)
        {
            if (task == null || task.TaskId == 0)
                return false;

            var t = _context.Tasks.FirstOrDefault(x => x.TaskId == task.TaskId);
            if (t == null)
                return false;
            t.Name = task.Name;
            t.Description = task.Description;

            _context.Tasks.Update(t);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Model.Task>> GetAllTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Model.Task> GetTaskById(int id)
        {
            return _context.Tasks.FirstOrDefault(f => f.TaskId == id);
        }
    }
}
