using Ms.Common;
using System;

namespace Ms.User.Entities
{
    public class UserEntity : IEntity
    {

        public Guid PersonId;
        public string Email { get; set; }
        public string Password { get; set; }


        public UserEntity()
        {

        }

        public UserEntity(Guid personId, string email, string password)
        {
            PersonId = personId;
            Email = email;
            Password = password;
        }

    }
}
