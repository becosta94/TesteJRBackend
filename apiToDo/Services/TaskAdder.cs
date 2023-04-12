using apiToDo.DTO;
using apiToDo.Exceptions;
using apiToDo.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiToDo.Services
{
    public class TaskAdder : ITaskAdder
    {
        public List<TarefaDTO> Add(List<TarefaDTO> listToAdd, TarefaDTO taskToAdd)
        {
            if (listToAdd.Select(e => e.ID_TAREFA).Contains(taskToAdd.ID_TAREFA))
                throw new ExistingIdException("ID já existe na lista");
            listToAdd.Add(taskToAdd);
            if (listToAdd == null || listToAdd.Count == 0)
                return null;
            return listToAdd;
        }
    }
}
