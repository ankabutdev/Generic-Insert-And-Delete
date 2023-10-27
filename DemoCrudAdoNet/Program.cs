using DemoCrudAdoNet.Entities.Users;
using DemoCrudAdoNet.Repositories.Users;

namespace DemoCrudAdoNet;

public class Program
{
    public static async Task Main(string[] args)
    {
        RunApp runApp = new RunApp(new UserRegisterRepository());

        var sqlExpressionVisitor = new SqlExpressionVisitor<object>();

        await runApp.RunAsync();

    }
}