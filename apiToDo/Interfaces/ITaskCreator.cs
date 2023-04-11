using apiToDo.DTO;
using System.Collections.Generic;

namespace apiToDo.Interfaces
{
    public interface ITaskCreator
    {
        public List<TarefaDTO> Create();
    }
}
