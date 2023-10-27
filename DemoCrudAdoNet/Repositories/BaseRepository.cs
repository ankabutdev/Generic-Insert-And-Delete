using System.Data.SqlClient;

namespace DemoCrudAdoNet.Repositories;

public class BaseRepository
{
    protected readonly SqlConnection _connection;

    protected readonly string CONNECTIONSTRING = @"Server=LAPTOP-UVN5MKL6\\SQLEXPRESS;Database=DemoMessageSender;Trusted_Connection=True;";

    public BaseRepository()
    {
        this._connection = new SqlConnection("Server=LAPTOP-UVN5MKL6\\SQLEXPRESS;Database=DemoMessageSender;Trusted_Connection=True;");
    }
}