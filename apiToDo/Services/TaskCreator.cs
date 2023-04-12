using apiToDo.DTO;
using apiToDo.Interfaces;
using apiToDo.Models;
using System.Collections.Generic;

namespace apiToDo.Services
{
    public class TaskCreator : ITaskCreator
    {
        private Tarefas _tarefas;

        public TaskCreator()
        {
            _tarefas = new Tarefas();
        }

        public List<TarefaDTO> Create()
        {
            List<TarefaDTO> tasks = _tarefas.lstTarefas();
            if (tasks == null || tasks.Count == 0)
                return null;
            return tasks;
        }
    }
}
