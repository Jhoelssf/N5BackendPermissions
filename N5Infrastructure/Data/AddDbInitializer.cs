using N5Domain.DTOs;
using N5Domain.Entities;
using Nest;

namespace N5Infrastructure.Data
{
    public static class AddDbInitializer
    {
        public static void Seed(ApplicationDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException();
            }

            if (dbContext.Permissions.Any() && dbContext.PermissionTypes.Any())
            {
                return;
            }

            var permissionTypesToAdd = new AddPermissionTypeDto[]
            {
                new AddPermissionTypeDto
                {
                    Description = "Vacation"
                },
                new AddPermissionTypeDto
                {
                    Description = "Sick Leave"
                },
                new AddPermissionTypeDto
                {
                    Description = "Maternity Leave"
                },
                new AddPermissionTypeDto
                {
                    Description = "Paternity Leave"
                },
                new AddPermissionTypeDto
                {
                    Description = "Bereavement Leave"
                },
                new AddPermissionTypeDto
                {
                    Description = "Other"
                }
            };

            foreach (var ptDto in permissionTypesToAdd)
            {
                var type = PermissionType.Create(ptDto);
                dbContext.PermissionTypes.Add(type);
            }

            dbContext.SaveChanges();

            var permissionsToAdd = new AddPermissionDto[]
            {
                new AddPermissionDto{
                    EmployeeForename = "Forename1",
                    EmployeeSurname = "Surname1",
                    PermissionDate = DateTime.Now,
                    PermissionTypeId = 1
                },
                new AddPermissionDto{
                    EmployeeForename = "Forename2",
                    EmployeeSurname = "Surname2",
                    PermissionDate = DateTime.Now,
                    PermissionTypeId = 1
                }
            };

            foreach (var dto in permissionsToAdd)
            {
                var permission = Permission.Create(dto);
                dbContext.Permissions.Add(permission);
            }

            dbContext.SaveChanges();
        }
    }
}
