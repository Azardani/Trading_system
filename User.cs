using UserApp;

namespace UserApp;

public class User
{
    public string Username { get; }
    public string Password { get; }


    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public bool TryLogin(string username, string password)
    {
        return Username == username && Password == password;
    }

}
