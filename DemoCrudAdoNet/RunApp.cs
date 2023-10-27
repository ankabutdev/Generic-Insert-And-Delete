using DemoCrudAdoNet.Repositories;
using DemoCrudAdoNet.Repositories.Users;

namespace DemoCrudAdoNet;

public class RunApp : BaseRepository
{
    private readonly UserRegisterRepository _userRepo;

    public RunApp(UserRegisterRepository repository)
    {
        this._userRepo = repository;
    }

    public async Task RunAsync()
    {
        string input_FirstName, input_LastName,
            input_email, input_password, inputMessage;

        int selectedId;


        //await _userRepo.CreateAsync(new User
        //{
        //    FirstName = "Jhon",
        //    LastName = "Doe",
        //    Email = "@gmail.com",
        //    Password = "password",
        //    Message = "MessageTest"
        //});


        Console.WriteLine
            (
                await _userRepo.DeleteAsync(x => x.Id == 3)
            );

        /*
        Console.WriteLine("All Users: \n");

        Console.WriteLine("Welcome");

        while (false)
        {
            Console.Write("FirstName: ");
            input_FirstName = Console.ReadLine()!;

            Console.Write("LastName: ");
            input_LastName = Console.ReadLine()!;

            Console.Write("Email: ");
            input_email = Console.ReadLine()!;

            Console.Write("Create Password: ");
            input_password = Console.ReadLine()!;

            Console.Write("Select Users You want to spoked (ID): ");

            //var userSelectId =  

        }
        */
    }
}
