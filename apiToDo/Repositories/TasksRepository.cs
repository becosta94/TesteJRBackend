using apiToDo.DTO;
using apiToDo.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiToDo.Repositories
{
    public class TasksRepository : ITaskGetter
    {
        private ITaskCreator _taskCreator;

        public TasksRepository(ITaskCreator taskCreator)
        {
            _taskCreator = taskCreator;
        }

        public List<TarefaDTO> Get()
        {
            List<TarefaDTO> tasksDTO = new List<TarefaDTO>();
            tasksDTO = _taskCreator.Create();
            if (tasksDTO.Count > 0) 
                return tasksDTO;
            else return null;
        }
    }
}
