using apiToDo.DTO;
using System.Collections.Generic;

namespace apiToDo.Interfaces
{
    public interface ITaskAdder
    {
        List<TarefaDTO> Add(List<TarefaDTO> listToAdd, TarefaDTO taskToAdd);
    }
}
