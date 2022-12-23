using System;
using System.ComponentModel.DataAnnotations;

namespace Ms.Common
{
    public class IEntity
    {

        [Key]
        public Guid Id { get; set; }
    }
}
