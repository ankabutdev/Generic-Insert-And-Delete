using DemoCrudAdoNet.Entities.Messages;
using DemoCrudAdoNet.Entities.Users;
using DemoCrudAdoNet.Interfaces.Users;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace DemoCrudAdoNet.Repositories.Users
{
    public class UserRegisterRepository : BaseRepository, IUserRegisterRepository
    {
        private SqlExpressionVisitor<User> _visitor;

        public UserRegisterRepository()
        {
            this._visitor = new SqlExpressionVisitor<User>();
        }

        public async Task<bool> CreateAsync(User entity)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "INSERT INTO Users (FirstName, LastName, Email, Password, Message) " +
                        "VALUES (@FirstName, @LastName, @Email, @Password, @Message);";

                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@FirstName", entity.FirstName);
                    command.Parameters.AddWithValue("@LastName", entity.LastName);
                    command.Parameters.AddWithValue("@Email", entity.Email);
                    command.Parameters.AddWithValue("@Password", entity.Password);
                    command.Parameters.AddWithValue("@Message", entity.Message);

                    var result = await command.ExecuteNonQueryAsync();

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<bool> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            try
            {
                await _connection.OpenAsync();

                string whereQuery = _visitor.Translate(expression);

                string query = $"DELETE FROM Users WHERE {whereQuery}";

                using (SqlCommand sqlCommand = new SqlCommand(query, _connection))
                {
                    var result = await sqlCommand.ExecuteNonQueryAsync();

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public Task<Message> GetMessagesByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterUser(string username, string password, string email)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> SelectAll(Expression<Func<User, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public async Task<User> SelectAsync(Expression<Func<User, bool>> expression)
        {
            try
            {
                await _connection.OpenAsync();

                string whereClause = _visitor.Translate(expression);

                string query = $"SELECT * FROM Users WHERE {whereClause}";

                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            User user = new User
                            {
                                Id = (int)reader["Id"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                Email = (string)reader["Email"],
                                Password = (string)reader["Password"],
                                Message = (string)reader["Message"]
                            };

                            return user;
                        }
                    }
                }
                return new User();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new User();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public Task<bool> SendMessage(int senderId, int receiverId, string messageContent)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}