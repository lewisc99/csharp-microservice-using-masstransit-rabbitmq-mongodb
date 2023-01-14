using static Ms.Common.Entities.Dtos.Dtos;

namespace Ms.User.Entities.Dtos
{
    public static class Extensions
    {
        public static UserEntity convertUserCreatedDtoToUSerEntity(this UserCreatedDto context)
        {
            UserEntity userEntity = new UserEntity(context.email, context.password);
            return userEntity;
            
        }
    }
}
