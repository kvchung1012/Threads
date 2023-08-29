using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thread.Contract.IdentityService.Responses.Roles;
using Threads.IdentityService.Domain.Entities;

namespace Threads.IdentityService.Application.Mappers.RoleProfile
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<ApplicationRole, ApplicationRoleResponse>();
            CreateMap<ApplicationRolePermission, ApplicationRolePermissionResponse>();
        }
    }
}
