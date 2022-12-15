using Microsoft.AspNetCore.Authorization;
using Project.Infrastructure.Accessories;

namespace Project.Infrastructure.Policy
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public List<Roles> RoleList { get; }
        public RoleRequirement(List<Roles> roleList) 
        {
            RoleList = roleList;
        }
    }
}
