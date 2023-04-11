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
        private ITaskGetter _taskGetter;

        public TarefasController(ITaskGetter taskGetter)
        {
            _taskGetter = taskGetter;
        }

        //[Authorize]
        [HttpPost("lstTarefas")]
        public ActionResult lstTarefas()
        {
            try
            {
                List<TarefaDTO> tarefaDTOs = _taskGetter.Get();
                if (tarefaDTOs == null)
                    throw new TaskListEmptyException("A lista de tarefas está vazia!");
                return StatusCode(200, tarefaDTOs);
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
        public ActionResult InserirTarefas([FromBody] TarefaDTO Request)
        {
            try
            {

                return StatusCode(200);


            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpGet("DeletarTarefa")]
        public ActionResult DeleteTask([FromQuery] int ID_TAREFA)
        {
            try
            {

                return StatusCode(200);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
    }
}
