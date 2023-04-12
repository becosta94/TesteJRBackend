using apiToDo.DTO;
using apiToDo.Exceptions;
using apiToDo.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Services
{
    public class TaskDeleter : ITaskDeleter
    {
        public List<TarefaDTO> Delete(List<TarefaDTO> listToDelete, int idToDelete)
        {
            //Verificação se o ID digitado não é nulo e se ele existe dentro da lista atual
            if (idToDelete == 0 || listToDelete.Where(e => e.ID_TAREFA == idToDelete).Count() == 0)
                throw new IdNotFoundException("ID não encontrado.");
            //Remoção da tarefa que tem o mesmo ID do input
            listToDelete.RemoveAll(e => e.ID_TAREFA == idToDelete);
            //Verificação se a lista está vazia ou é nula
            if (listToDelete == null || listToDelete.Count == 0)
                return null;
            return listToDelete;
        }
    }
}
