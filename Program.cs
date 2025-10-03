using UserApp;
class User
{
    public string Username { get; }
    private string Password { get; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public bool TryLogin(string username, string password)
    {
        return username == Username && password == Password;
    }
}

class Program
{
    static void Main()
    {
        List<User> users = new List<User>();
        users.Add(new User("Azar", "Dani"));

        User? active_user = null;
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the trading site");
            Thread.Sleep(2000);

            if (active_user == null)
            {
                Console.WriteLine("Sign in to begin");

                Console.Write("Username: ");
                string username = Console.ReadLine();

                Console.Write("Password: ");
                string password = Console.ReadLine();

                foreach (User user in users)
                {
                    if (user.TryLogin(username, password))
                    {
                        active_user = user;
                        Console.WriteLine($"Welcome {user.Username}!");
                        Thread.Sleep(2000);
                        break;
                    }
                }

                if (active_user == null)
                {
                    Console.WriteLine("Login failed, try again...");
                    Thread.Sleep(2000);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"You are logged in as {active_user.Username}");
                Console.WriteLine("Type 'logout' to sign out, or 'quit' to exit program.");

                string cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "logout":
                        active_user = null;
                        break;

                    case "quit":
                        running = false;
                        break;
                }
            }
        }
    }
}