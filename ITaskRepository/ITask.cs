namespace TaskWebApiAssessment.ITaskRepository
{
    public interface ITask
    {
       

        public Task<IEnumerable<Model.Task>> GetAllTasks();

        public Task<bool> AddTask(Model.Task task);

        public Task<Model.Task> GetTaskById(int id);

        public Task<bool> DeleteTask(int id);

        public Task<bool> Edit(Model.Task task);

        

    }
}

