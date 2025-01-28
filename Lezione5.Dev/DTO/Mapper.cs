using Lezione5.Dev.Entities;

namespace Lezione5.Dev.DTO
{
    public class Mapper
    {
        public UserDTO MapEntityToDTO(User user) => new UserDTO()
        {
            Id = user.Id,
            Nickname = user.Nickname
        };

        public User MapDTOToEntity(NewUserDTO newUser) => new User()
        {
            Nickname = newUser.Nickname,
            Password = newUser.Password
        };
    }
}
