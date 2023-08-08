using MediatR;
using Microsoft.AspNetCore.Mvc;
using N5Api.Services;
using N5Application.Commands;
using N5Application.DTO;
using N5Application.Queries;
using System.Threading;

namespace N5Api.Controllers
{
    public class PermissionsController : BaseController, IPermissionService
    {
        public PermissionsController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        [ProducesResponseType(typeof(CreatePermissionResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreatePermission([FromBody] AddPermissionDto dto, CancellationToken cancellationToken)
        {
            var request = new CreatePermissionCommand(dto.EmployeeForename, dto.EmployeeSurname, dto.PermissionTypeId);
            return Result(await Mediator.Send(request, cancellationToken));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdatePermissionResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdatePermission([FromRoute(Name = "id")] int id, [FromBody] UpdatePermissionDto dto, CancellationToken cancellationToken)
        {
            var request = new UpdatePermissionCommand(id, dto.EmployeeForename, dto.EmployeeSurname, dto.PermissionDate, dto.PermissionTypeId);
            return Result(await Mediator.Send(request, cancellationToken));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PermissionDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPermissions(CancellationToken cancellationToken)
        {
            return Result(await Mediator.Send(new GetAllPermissions(), cancellationToken));
        }
    }
}