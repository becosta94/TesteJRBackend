using apiToDo.DTO;
using System.Collections.Generic;

namespace apiToDo.Interfaces
{
    public interface ITaskUpdater
    {
        List<TarefaDTO> Update(List<TarefaDTO> listToAdd, TarefaDTO taskToAdd);
    }
}
