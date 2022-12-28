using Ms.Common;

namespace Ms.User.Entities
{
    public class User : IEntity
    {
        public string Email { get; set; }
        
        public string Password { get; set; }

    }
}
