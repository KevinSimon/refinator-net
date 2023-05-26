using Refinator.Models.Base;

namespace Refinator.Models.User
{
    public class UserModel : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
