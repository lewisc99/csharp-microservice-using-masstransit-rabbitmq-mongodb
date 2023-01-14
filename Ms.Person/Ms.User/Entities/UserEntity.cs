using Ms.Common;

namespace Ms.User.Entities
{
    public class UserEntity : IEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }


        public UserEntity()
        {

        }

        public UserEntity(string email, string password)
        {
            Email = email;
            Password = password;
        }

    }
}
