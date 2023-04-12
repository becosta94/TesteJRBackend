using apiToDo.DTO;
using apiToDo.Exceptions;
using apiToDo.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Services
{
    public class TaskGetterById : ITaskGetterById
    {
        public TarefaDTO Get(List<TarefaDTO> taskList, int taskId)
        {
            if (!taskList.Select(e => e.ID_TAREFA).Contains(taskId))
                throw new IdNotFoundException($"Tarefa com ID = {taskId} não encontrada.");
            return taskList.Where(e => e.ID_TAREFA == taskId).First();           
        }
    }
}
