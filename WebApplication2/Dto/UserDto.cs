using Microsoft.AspNetCore.Identity;

namespace WebApplication2.Dto
{
    public class UserDto 
    {
        public int UserId { get; set; }

        public string UserLognId { get; set; } 

        public string PassKey { get; set; }   

        public int Role { get; set; }

        public string Name { get; set; } 
    }
}
