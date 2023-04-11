using apiToDo.DTO;
using apiToDo.Interfaces;
using apiToDo.Models;
using System.Collections.Generic;

namespace apiToDo.Services
{
    public class TaskCreator : ITaskCreator
    {
        public List<TarefaDTO> Create()
        {
            Tarefas task = new Tarefas();
            return task.lstTarefas();
        }
    }
}
