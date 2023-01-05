using Ms.Common;
using System;

namespace Ms.User.Entities
{
    public class User : IEntity
    {

        public string Email { get; set; }
        public string Password { get; set; }

        public Guid PersonId { get; set; }

        public string name { get; set; }

    }
}
