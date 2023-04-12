using apiToDo.DTO;
using apiToDo.Exceptions;
using apiToDo.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Services
{
    public class TaskUpdater : ITaskUpdater
    {
        public List<TarefaDTO> Update(List<TarefaDTO> listToUpdate, TarefaDTO taskToAdd)
        {
            if (!listToUpdate.Select(e => e.ID_TAREFA).Contains(taskToAdd.ID_TAREFA))
                throw new IdNotFoundException($"Tarefa com ID = {taskToAdd.ID_TAREFA} não encontrada");
            listToUpdate.Where(e => e.ID_TAREFA == taskToAdd.ID_TAREFA).First().DS_TAREFA = taskToAdd.DS_TAREFA;
            if (listToUpdate == null || listToUpdate.Count == 0)
                return null;
            return listToUpdate;
        }
    }
}
