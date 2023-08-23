using Application.DTOs.Todos;
using Application.Features.Todos.Commands.AddTodo;
using Application.Features.Todos.Commands.DeleteTodo;
using Application.Features.Todos.Commands.UpdateTodo;
using Application.Features.Todos.Queries.GetAllTodos;
using Application.Features.Todos.Queries.GetTodoById;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private string ItemName = "Todo";

        private readonly IMediator _mediator;

        public TodosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllTodos(string? searchText)
        {
            var results = await _mediator.Send(new GetAllTodosQuery
            {
                SearchText = searchText,
            });

            return Ok(results);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTodo(int id)
        {
            var result = await _mediator.Send(new GetTodoByIdQuery
            {
                TodoId = id
            });

            if (result == null)
            {
                return NotFound(ControllerResponses.NotFound(ItemName, id));
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddTodo([FromBody] AddTodoDto dto)
        {
            var result = await _mediator.Send(new AddTodoCommand
            {
                dto = dto
            });

            return Accepted(ControllerResponses.Created(ItemName));
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateTodo(int id, [FromBody] UpdateTodoDto dto)
        {
            if (id != dto.Id) return BadRequest("Id In route must match with id in the body");

            var result = await _mediator.Send(new UpdateTodoCommand
            {
                TodoId = id,
                dto = dto
            });

            return result == 0 ? NotFound(ControllerResponses.NotFound(ItemName, id)) : Accepted(ControllerResponses.Updated(ItemName, id));
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var result = await _mediator.Send(new DeleteTodoCommand
            {
                TodoId = id
            });

            return result == 0 ? NotFound(ControllerResponses.NotFound(ItemName, id)) : Ok(ControllerResponses.Deleted(ItemName, id));
        }
    }
}
