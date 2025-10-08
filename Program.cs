namespace UserApp;

    class Program
    {
        static void Main()
        {
            List<User> users = new List<User>();

            // läsa in användare från fil, ifall den finns
            if (File.Exists("users.txt"))
            {
                foreach (var line in File.ReadAllLines("users.txt"))
                {
                    string[] parts = line.Split(';');
                    if (parts.Length == 2)
                        users.Add(new User(parts[0], parts[1]));
                }
            }

            User active_user = null;
            bool is_running = true;

            while (is_running)
            {
                Console.Clear();

                if (active_user == null)
                {
                    Console.WriteLine("Welcome to Trade App!");
                    Thread.Sleep(1500);
                    Console.WriteLine("\n1. Sign up");
                    Console.WriteLine("2. Log in");
                    Console.WriteLine("3. Save users");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nChoose option: ");
                    string cases = Console.ReadLine();

                    switch (cases)
                    {
                        case "1":
                            Console.Write("Choose a username: ");
                            string username = Console.ReadLine();

                            bool usernameTaken = false;
                            foreach (User user in users)
                            {
                                if (user.Username == username)
                                {
                                    usernameTaken = true;
                                    break;
                                }
                            }

                            if (usernameTaken)
                            {
                                Console.WriteLine("That username is taken!");
                                Thread.Sleep(1500);
                                break;
                            }

                            Console.Write("Choose a password: ");
                            string password = Console.ReadLine();

                            users.Add(new User(username, password));
                            Console.WriteLine("User registered successfully!");
                            Thread.Sleep(1500);
                            break;

                        case "2":
                            Console.Write("Username: ");
                            string loginUser = Console.ReadLine();
                            Console.Write("Password: ");
                            string loginPass = Console.ReadLine();

                            foreach (User user in users)
                            {
                                if (user.TryLogin(loginUser, loginPass))
                                {
                                    active_user = user;
                                    Console.WriteLine($"Welcome {user.Username}, {user.Password}");
                                    Thread.Sleep(1500);
                                    break;
                                }
                            }

                            if (active_user == null)
                            {
                                Console.WriteLine("Invalid username or password!");
                                Thread.Sleep(1500);
                            }
                            break;

                        case "3":
                            using (StreamWriter sw = new StreamWriter("users.txt"))
                            {
                                foreach (User user in users)
                                {
                                    sw.WriteLine($"{user.Username};{user.Password}");
                                }
                            }
                            Console.WriteLine("Users saved successfully!");
                            Thread.Sleep(1500);
                            break;

                        case "4":
                            is_running = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option!");
                            Thread.Sleep(1500);
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"You are logged in as {active_user.Username}");
                    Console.WriteLine("Type 'logout' to sign out:");
                    string cmd = Console.ReadLine();

                    if (cmd.ToLower() == "logout")
                    {
                        active_user = null;
                        Console.WriteLine("You have logged out.");
                        Thread.Sleep(1000);
                    }
                }
            }
        }
    }














