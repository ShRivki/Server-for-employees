using Solid.Core.Entities;

namespace Solid.API.models
{
    public class EmployeeRolePostModel
    {
      
        public RolePostModel Role { get; set; }
        public bool IsManagement { get; set; }
        public DateTime StartDate { get; set; }
    }
}
