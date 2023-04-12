using apiToDo.DTO;
using System.Collections.Generic;

namespace apiToDo.Interfaces
{
    public interface ITaskGetterById
    {
        TarefaDTO Get(List<TarefaDTO> taskList, int taskId);
    }
}
