using Microsoft.AspNetCore.Mvc;
using N5Application.DTO;

namespace N5Api.Services
{
    public interface IPermissionService
    {
        Task<IActionResult> UpdatePermission(int id, UpdatePermissionDto dto, CancellationToken cancellationToken);
        Task<IActionResult> CreatePermission(AddPermissionDto dto, CancellationToken cancellationToken);
        Task<IActionResult> GetPermissions(CancellationToken cancellationToken);
    }
}