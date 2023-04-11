using apiToDo.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiToDo.Interfaces
{
    public interface ITaskGetter
    {
        List<TarefaDTO> Get();
    }
}
