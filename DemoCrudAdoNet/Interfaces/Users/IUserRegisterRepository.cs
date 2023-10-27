using DemoCrudAdoNet.Entities.Messages;
using DemoCrudAdoNet.Entities.Users;

namespace DemoCrudAdoNet.Interfaces.Users;

public interface IUserRegisterRepository : IRepository<User>
{
    public Task<bool> RegisterUser(string username, string password, string email);

    public Task<bool> SendMessage(int senderId, int receiverId, string messageContent);

    public Task<User> GetUserById(int userId);

    public Task<User> GetUserByUsername(string username);

    public Task<Message> GetMessagesByUserId(int userId);
}
