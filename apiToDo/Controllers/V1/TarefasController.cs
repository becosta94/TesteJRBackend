using apiToDo.DTO;
using apiToDo.Exceptions;
using apiToDo.Interfaces;
using apiToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace apiToDo.Controllers.V1
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        private ITaskCreator _taskCreator;
        private ITaskAdder _taskAdder;
        private ITaskDeleter _taskDeleter;
        private ITaskUpdater _taskUpdater;
        private ITaskGetterById _taskGetterById;

        public TarefasController(ITaskCreator taskCreator, ITaskAdder taskAdder, ITaskDeleter taskDeleter, ITaskUpdater taskUpdater, ITaskGetterById taskGetterById)
        {
            _taskCreator = taskCreator;
            _taskAdder = taskAdder;
            _taskDeleter = taskDeleter;
            _taskUpdater = taskUpdater;
            _taskGetterById = taskGetterById;
        }

        //[Authorize]
        [HttpGet("lstTarefas")]
        public ActionResult lstTarefas()
        {
            try
            {
                List<TarefaDTO> tasks = _taskCreator.Create();
                if (tasks == null)
                    throw new TaskListEmptyException("A lista de tarefas está vazia.");
                return StatusCode(200, tasks);
            }
            catch (TaskListEmptyException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpPost("InserirTarefas")]
        public ActionResult InserirTarefas([FromBody] TarefaDTO request)
        {
            try
            {
                if (request == null || request.ID_TAREFA == 0 || string.IsNullOrEmpty(request.DS_TAREFA))
                    throw new TaskToAddNullException("A tarefa ou um de seus atributos não pode estar vazia.");
                List<TarefaDTO> tasks = _taskCreator.Create();
                _taskAdder.Add(tasks, request);
                if (tasks == null)
                    throw new TaskListEmptyException("A lista de tarefas está vazia.");
                return StatusCode(200, tasks);
            }
            catch (TaskListEmptyException ex)
            {
                return StatusCode(400, ex.Message);
            }            
            catch (TaskToAddNullException ex)
            {
                return StatusCode(400, ex.Message);
            }            
            catch (ExistingIdException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpDelete("DeletarTarefa")]
        public ActionResult DeleteTask([FromQuery] int ID_TAREFA)
        {
            try
            {
                //Criação das tarefas
                List<TarefaDTO> tasks = _taskCreator.Create();
                //Implementação da classe de deletar tarefas
                _taskDeleter.Delete(tasks, ID_TAREFA);
                //Tratamento caso a lista esteja vazia
                if (tasks == null)
                    throw new TaskListEmptyException("A lista de tarefas está vazia.");
                return StatusCode(200, tasks);
            }
            catch (TaskListEmptyException ex)
            {
                return StatusCode(400, ex.Message);
            }            
            catch (IdNotFoundException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
        [HttpPut("AtualizarTarefas")]
        public ActionResult UpdateTask([FromBody] TarefaDTO request)
        {
            try
            {
                if (request == null || request.ID_TAREFA == 0 || string.IsNullOrEmpty(request.DS_TAREFA))
                    throw new TaskToAddNullException("A tarefa ou um de seus atributos não pode estar vazia.");
                List<TarefaDTO> tasks = _taskCreator.Create();
                _taskUpdater.Update(tasks, request);
                if (tasks == null)
                    throw new TaskListEmptyException("A lista de tarefas está vazia.");
                return StatusCode(200, tasks);
            }
            catch (TaskListEmptyException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (TaskToAddNullException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (IdNotFoundException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }        
        [HttpGet("ObterTarefaPorId")]
        public ActionResult GetById(int id)
        {
            try
            {
                List<TarefaDTO> tasks = _taskCreator.Create();
                if (tasks == null)
                    throw new TaskListEmptyException("A lista de tarefas está vazia.");
                TarefaDTO task = _taskGetterById.Get(tasks, id);
                return StatusCode(200, task);
            }
            catch (TaskListEmptyException ex)
            {
                return StatusCode(400, ex.Message);
            }            
            catch (IdNotFoundException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
    }
}
