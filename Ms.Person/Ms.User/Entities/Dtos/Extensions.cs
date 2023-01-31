using static Ms.Common.Entities.Dtos.Dtos;

namespace Ms.User.Entities.Dtos
{
    public static class Extensions
    {
        public static UserEntity convertUserCreatedDtoToUserEntity(this UserCreatedDto context)
        {
            UserEntity userEntity = new UserEntity(context.id, context.email, context.password);
            return userEntity;
            
        }

    }
}
