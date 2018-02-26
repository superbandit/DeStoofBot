

namespace DeStoofBot.Models
{
    public class UserMessage
    {
        public string Channel { get; set; }
        public string User { get; set; }
        public int UserRole { get; set; } = (int)Enums.UserRoles.User;//Default to user role
        public string Message { get; set; }
    }
}
