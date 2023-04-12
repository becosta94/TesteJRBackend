using apiToDo.DTO;
using System.Collections.Generic;

namespace apiToDo.Interfaces
{
    public interface ITaskDeleter
    {
        List<TarefaDTO> Delete(List<TarefaDTO> listToDelete, int idToDelete);
    }
}
